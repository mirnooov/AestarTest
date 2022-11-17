using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace AnythingWorld.Utilities
{
    [InitializeOnLoad]
    public class AutoRunUtil
    {
        static AutoRunUtil()
        {
#if UNITY_EDITOR
            if(!SessionState.GetBool("AutoRunUtilCalled", false))
            {
                EditorApplication.update += RunOnce;
                SessionState.SetBool("AutoRunUtilCalled", true);
            }
#endif
        }
#if UNITY_EDITOR
        static void RunOnce()
        {

            VersionCheckEditor.DisplayUpdateDialogue();
            EditorApplication.update -= RunOnce;

        }
#endif
    }
}
#endif
