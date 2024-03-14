namespace EditorTools
{
    using System;
    using UnityEditor;

    public static class Align 
    {
        public static void Horizontal(Action values)
        {
            EditorGUILayout.BeginHorizontal();
            values?.Invoke();
            EditorGUILayout.EndHorizontal();
        }

        public static void Vertical(Action values)
        {
            EditorGUILayout.BeginVertical();
            values?.Invoke();
            EditorGUILayout.EndVertical();
        }
    }
}

