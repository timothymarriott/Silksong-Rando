using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Silksong.Rando.Locations;

namespace Silksong.Rando.Logic
{
    [Serializable]
    public class LogicFile
    {
        public string start;

        public string[] required;
        
        public Dictionary<string, LogicNode> nodes;

        [JsonIgnore]
        public LogicNode StartNode => nodes[start];

        public static LogicFile Load(string name)
        {
            return JsonConvert.DeserializeObject<LogicFile>(ModResources.LoadData(name));
        }

        public bool HasCheck(string id)
        {
            foreach (var (nodeId, node) in nodes)
            {
                if (node.checks != null)
                {
                    foreach (var check in node.checks)
                    {
                        if (check == id)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public Dictionary<string, string> GenerateSeed(int seed = -1)
        {
            var rng = new Random();
            if (seed != -1)
            {
                rng = new Random(seed);
            }
            
            var locationData = JsonConvert.DeserializeObject<Dictionary<string, ItemLocationData>>(ModResources.LoadData("locations"));
            
            var allLocations = locationData.Keys;
            
            var placements = new Dictionary<string, string>();

            var reachable = new HashSet<string> { start };
            
            var nodeChecks = new Dictionary<string, List<string>>();
            foreach (var (nodeId, node) in nodes)
            {
                var list = new List<string>();
                if (node.checks != null)
                {
                    foreach (var c in node.checks)
                        if (allLocations.Contains(c))
                            list.Add(c);
                }

                Shuffle(list, rng);
                nodeChecks[nodeId] = list;
            }
            
            var obtainedItems = new HashSet<string>();

            void RefreshReachable(ref bool progress)
            {
                foreach (var from in reachable.ToArray())
                {
                    foreach (var edge in nodes[from].edges ?? Array.Empty<NodeEdge>())
                    {
                        if (!reachable.Contains(edge.to) && EdgeSatisfied(edge, obtainedItems))
                        {
                            reachable.Add(edge.to);
                            progress = true;
                        }
                    }
                }
            }
            
            List<string> GetReachableChecks(ref bool progress)
            {
                List<string> res = new List<string>();
                
                RefreshReachable(ref progress);

                foreach (var node in reachable.ToArray())
                {
                    foreach (var check in nodeChecks[node])
                    {
                        if (!placements.ContainsKey(check))
                        {
                            res.Add(check);
                        }
                    }

                    
                }
                Shuffle(res, rng);

                return res;
            }
            
            

            var allItems = new HashSet<string>();
            foreach (var checks in nodeChecks.Values)
                foreach (var c in checks)
                    allItems.Add(c.Split('|')[1]);

            
            


            bool progress;

            do
            {
                progress = false;
                
                placed:
                RefreshReachable(ref progress);
                foreach (var from in reachable.ToArray())
                {
                    foreach (var edge in nodes[from].edges ?? Array.Empty<NodeEdge>())
                    {
                        if (reachable.Contains(edge.to))
                            continue;

                        foreach (var req in ParseReq(edge.req))
                        {
                            if (obtainedItems.Contains(req))
                                continue;

                            ForcePlaceItem(req, placements, nodes[from].checks.ToList(), rng);
                            obtainedItems.Add(req);
                            progress = true;
                            goto placed;
                        }
                    }
                }

                RefreshReachable(ref progress);
            } while (progress);

            if (reachable.Count != nodes.Count)
                throw new Exception("Unreachable nodes remain after placement");
            
            foreach (var item in required)
            {
                placements[GetReachableChecks(ref progress)[0]] = item;
                obtainedItems.Add(item);
            }

            var remainingItems = new List<string>();

            foreach (var node in nodes)
            {
                foreach (var check in node.Value.checks)
                {
                    string itm = check.Split("|", 2)[1];
                    if (!obtainedItems.Contains(itm))
                    {
                        remainingItems.Add(itm);
                    }
                }
            }

            foreach (var check in GetReachableChecks(ref progress))
            {
                if (!placements.ContainsKey(check))
                {
                    if (remainingItems.Count > 0)
                    {
                        placements[check] = remainingItems[0];
                        obtainedItems.Add(remainingItems[0]);
                        remainingItems.RemoveAt(0);
                    }
                    else
                    {
                        RandoPlugin.Log.LogWarning("Ran out of items");
                    }

                }
            }

            /*
            var remainingItems = new List<string>();
            foreach (var item in allItems)
                if (!obtainedItems.Contains(item))
                    remainingItems.Add(item);

            Shuffle(remainingItems, rng);

            foreach (var check in GetReachableChecks(ref progress))
            {
                if (!placements.ContainsKey(check))
                {
                    if (remainingItems.Count > 0)
                    {
                        placements[check] = remainingItems[0];
                        remainingItems.RemoveAt(0);
                    }
                    else
                    {
                        RandoPlugin.Log.LogWarning("Ran out of items");
                    }

                }
            }
            */

            return placements;
        }
        
        private static IEnumerable<string> ParseReq(string? req)
        {
            if (string.IsNullOrWhiteSpace(req) || req == "true")
                yield break;

            yield return req;
        }

        private static bool ForcePlaceItem(
            string item,
            Dictionary<string, string> placements,
            List<string> reachable, 
            Random rng)
        {
            foreach (var check in Shuffled(reachable, rng))
            {
                if (!placements.ContainsKey(check))
                {
                    placements[check] = item;
                    RandoPlugin.Log.LogInfo("Force placed " + item);
                    return true;
                }
            }
            return false;
        }

        
        private static bool EdgeSatisfied(NodeEdge edge, HashSet<string> obtainedItems)
        {
            if (string.IsNullOrWhiteSpace(edge.req) || edge.req == "true")
                return true;

            
            if (!obtainedItems.Contains(edge.req))
                return false;
            

            return true;
        }

        private static void Shuffle<T>(IList<T> list, Random rng)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        
        private static IList<T> Shuffled<T>(IList<T> list, Random rng)
        {
            var res = list.ToList();
            Shuffle(res, rng);
            return res;
        }
        
    }

    [Serializable]
    public class LogicNode
    {
        public NodeEdge[] edges;
        public string[] checks;
    }

    [Serializable]
    public class NodeEdge
    {
        public string to;
        public string req = "true";
    }
}