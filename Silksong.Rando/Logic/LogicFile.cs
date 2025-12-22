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

            var allItems = new HashSet<string>();
            foreach (var checks in nodeChecks.Values)
                foreach (var c in checks)
                    allItems.Add(c.Split('|')[1]);

            var placements = new Dictionary<string, string>();
            var obtainedItems = new HashSet<string>();

            var reachable = new HashSet<string> { start };

            bool progress;

            do
            {
                progress = false;

                // 1. Find blocking edges
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

                            if (!ForcePlaceItem(req, reachable, nodeChecks, placements))
                                throw new Exception($"Cannot place required item: {req}");

                            obtainedItems.Add(req);
                            progress = true;
                        }
                    }
                }

                // 2. Recompute reachability
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

            } while (progress);

            if (reachable.Count != nodes.Count)
                throw new Exception("Unreachable nodes remain after placement");

            // 3. Fill remaining checks arbitrarily
            var remainingItems = new List<string>();
            foreach (var item in allItems)
                if (!obtainedItems.Contains(item))
                    remainingItems.Add(item);

            Shuffle(remainingItems, rng);

            foreach (var (nodeId, checks) in nodeChecks)
            {
                foreach (var check in checks)
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
            }

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
            HashSet<string> reachable,
            Dictionary<string, List<string>> nodeChecks,
            Dictionary<string, string> placements)
        {
            
            foreach (var node in reachable)
            {
                foreach (var check in nodeChecks[node])
                {
                    if (!placements.ContainsKey(check))
                    {
                        placements[check] = item;
                        RandoPlugin.Log.LogInfo("Force placed " + item);
                        return true;
                    }
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