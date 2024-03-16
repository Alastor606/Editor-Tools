#if UNITY_EDITOR
namespace EditorTools
{
    using System;
    using UnityEditor;
    using UnityEngine;

    public static class ObjectTools
    {
        public static int Field(ref this int self, string label = null, int max = -1, int min = -1)
        {
            if(min != -1 || max != -1)
            {
                if (label == null) self = EditorGUILayout.IntSlider(self, min, max);
                else self = EditorGUILayout.IntSlider(label, self, min, max);
            }
            else
            {
                if (label == null) self = EditorGUILayout.IntField(self);
                else self = EditorGUILayout.IntField(label, self);
            }
            return self;
           
        }

        public static float Field(ref this float self, string label = null, float max = -1, float min = -1)
        {
            if (min != -1 || max != -1)
            {
                if (label == null) self = EditorGUILayout.Slider(self, min, max);
                else self = EditorGUILayout.Slider(label, self, min, max);
            }
            else
            {
                if (label == null) self = EditorGUILayout.FloatField(self);
                else self = EditorGUILayout.FloatField(label, self);
            }
            return self;
        }

        public static bool Field(this ref bool self, string label = null, bool Horizontal = true, int size = 20)
        {
            if (Horizontal) GUILayout.BeginHorizontal();
            else GUILayout.BeginVertical();
            GUILayout.Label(label);

            Color originalColor = GUI.backgroundColor;
            GUI.backgroundColor = self ? Color.green : Color.white;

            if (GUILayout.Button("", GUILayout.Width(size), GUILayout.Height(size))) self = !self;
            
            GUI.backgroundColor = originalColor;
            if (Horizontal) GUILayout.EndHorizontal();
            else GUILayout.EndVertical();
            return self;
        }
        
        public static Color Field(this ref Color self, string label = null)
        {
            if (label == null) self = EditorGUILayout.ColorField(self);
            else self = EditorGUILayout.ColorField(label, self);
            return self;
        }

        public static void Space<T>(this T self, int value = 0) =>
            EditorGUILayout.Space(value);

        public static void Settings(this EditorWindow self)
        {
            Type inspectorType = Type.GetType("UnityEditor.InspectorWindow,UnityEditor.dll");
            SettingsWindow window = EditorWindow.GetWindow<SettingsWindow>(new Type[] { inspectorType });
            window.Init(self);
        }
        
    }
}
#endif