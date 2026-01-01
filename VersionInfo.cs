using System;
using System.Collections;
using System.Xml.Linq;
using Generated;
using UnityEngine.Networking;

namespace Silksong.Rando
{
    public static class VersionInfo
    {

        public delegate void OnFetched(long status, string statusText, bool outOfDate, string latest);

        public static void FetchInfo(OnFetched onFetched)
        {
            RandoPlugin.instance.StartCoroutine(fetchInfo(onFetched));
        }

        static IEnumerator fetchInfo(OnFetched onFetched)
        {
            string url =
                $"https://raw.githubusercontent.com/{BuildConstants.GitHubRepo}/refs/heads/main/Directory.Build.props";

            using var request = UnityWebRequest.Get(url);
            request.timeout = 30;

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                onFetched(request.responseCode, $"Failed to fetch latest version error code {request.responseCode.ToString()}", false, "");
                yield break;
            }

            var txt = request.downloadHandler.text;

            var info = ParseProjectXml(txt);

            if (!Version.TryParse(BuildConstants.Version, out var current))
            {
                onFetched(0, $"Current version \"{BuildConstants.Version}\" is invalid.", true, info.Version);
                yield break;
            }

            if (!Version.TryParse(info.Version, out var latest))
            {
                onFetched(0, $"Latest version \"{info.Version}\" is invalid.", false, info.Version);
                yield break;
            }


            onFetched(request.responseCode, "", current < latest, info.Version);
        }
        
        private sealed class ProjectInfo
        {
            public string AssemblyTitle;
            public string Version;
            public string GitHubRepo;
        }
        
        private static ProjectInfo ParseProjectXml(string xml)
        {
            var doc = XDocument.Parse(xml);

            var propertyGroup = doc.Root?.Element("PropertyGroup");

            return new ProjectInfo
            {
                AssemblyTitle = propertyGroup.Element("AssemblyTitle")?.Value,
                Version       = propertyGroup.Element("Version")?.Value,
                GitHubRepo    = propertyGroup.Element("GitHubRepo")?.Value
            };
        }
        
    }
}