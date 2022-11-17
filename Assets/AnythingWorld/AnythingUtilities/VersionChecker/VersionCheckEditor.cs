using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

using UnityEngine.Networking;
using UnityEngine;
#if UNITY_EDITOR
using Unity.EditorCoroutines.Editor;
#endif

namespace AnythingWorld.Utilities
{
#if UNITY_EDITOR
    public class VersionCheckEditor : Editor
    {

        public static void DisplayUpdateDialogue()
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                EditorCoroutineUtility.StartCoroutineOwnerless(GetVersion("http://anything-world-api.appspot.com/version"));
            }
#endif
        }

        private static IEnumerator GetVersion(string uri)
        {
            using (UnityWebRequest uwr = UnityWebRequest.Get(uri))
            {
                yield return uwr.SendWebRequest();



                if (uwr.result == UnityWebRequest.Result.Success)
                {
                    VersionResponse response = VersionResponse.CreateFromJson(uwr.downloadHandler.text);

                    if (response.version != AnythingSettings.PackageVersion && !AnythingSettings.PackageVersion.Contains("EA") &&!AnythingSettings.PackageVersion.Contains("b") && !AnythingSettings.PackageVersion.Contains("a"))
                    {
#if UNITY_EDITOR
                        if (EditorUtility.DisplayDialog("Update Anything World", response.message, "Get Now", "Exit"))
                        {
                            Application.OpenURL(response.downloadLink);
                        }
#endif
                    }
                }




            }


            yield return null;
        }

        [System.Serializable]
        public class VersionResponse
        {
            public string downloadLink;
            public string version;
            public string message;

            public static VersionResponse CreateFromJson(string jsonString)
            {
                return JsonUtility.FromJson<VersionResponse>(jsonString);
            }
        }

    }
#endif

}
#endif
