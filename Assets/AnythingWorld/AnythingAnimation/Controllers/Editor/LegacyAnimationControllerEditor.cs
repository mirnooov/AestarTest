using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace AnythingWorld.Animation
{
    [CustomEditor(typeof(LegacyAnimationController),true)]
    public class LegacyAnimationControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

        }
    }
}
#endif
