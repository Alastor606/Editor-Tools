#if UNITY_EDITOR
namespace EditorTools
{
    using System;
    using UnityEditor;
    using UnityEngine;

    public static class Draw 
    {
        public static string TextField(ref string self, string label = null, bool isTextArea = false)
        {
            if (isTextArea)
            {
                if (label == null) self = EditorGUILayout.TextArea(self);
                else self = EditorGUILayout.TextArea(label, self);
            }
            else
            {
                if (label == null) self = EditorGUILayout.TextField(self);
                else self = EditorGUILayout.TextField(label, self);
            }
            return self;
        }

        public static T ObjectField<T>(ref T obj, string label = null, bool allowSceneObjects = false) where T : UnityEngine.Object
        {
            if (label == null) obj = (T)EditorGUILayout.ObjectField(obj, typeof(T), allowSceneObjects);
            else obj = (T)EditorGUILayout.ObjectField(label, obj, typeof(T), allowSceneObjects);
            return obj;
        }

        public static void Label(string value, int fontSize = 13, Color color = default, TextAnchor aligment = default, float Space = 0)
        {
            GUIStyle style = new();
            style.normal.textColor = color == default ? Color.white : color;
            style.fontSize = fontSize;
            style.alignment = aligment == default ? TextAnchor.UpperLeft : aligment;
            EditorGUILayout.LabelField(value, style);
            if(Space != 0) EditorGUILayout.Space(Space);
        }

        public static void Label(string value, float Space = 0, params GUILayoutOption[] styles)
        {
            EditorGUILayout.LabelField(value, styles);
            if (Space != 0) EditorGUILayout.Space(Space);
        }

        public static bool Button(string label, Action toDo)
        {
            if (GUILayout.Button(label))
            {
                toDo?.Invoke();
                return true;
            }
            return false;
        }

        public static bool Button(Rect rect, string label, Action toDo)
        {
            if (GUI.Button(rect,label))
            {
                toDo?.Invoke();
                return true;
            }
            return false;
        }

    }
}

#endif