#if UNITY_EDITOR

namespace EditorTools
{
    using System;
    using UnityEditor;
    using UnityEngine;

    public static class Align 
    {
        private static Rect CenterPos(EditorWindow self) =>
            new(self.position.width / 4, self.position.height / 4, self.position.width / 2, self.position.height / 2);

        private static Rect TopPos(EditorWindow self) =>
            new(self.position.width / 4, self.position.height / 15, self.position.width / 2, self.position.height / 2);

        private static Rect BottomPos(EditorWindow self) =>
            new(self.position.width / 4, self.position.yMax /1.4f ,self.position.width / 2,self.position.height / 2);

        
        public static void Center(EditorWindow window, Action toDo)
        {
            GUILayout.BeginArea(CenterPos(window));
            toDo?.Invoke(); 
            GUILayout.EndArea();
        }

        public static void Bottom(EditorWindow window, Action toDo)
        {
            GUILayout.BeginArea(BottomPos(window));
            toDo?.Invoke();
            GUILayout.EndArea();
        }

        public static void Top(EditorWindow window, Action toDo)
        {
            GUILayout.BeginArea(TopPos(window));
            toDo?.Invoke();
            GUILayout.EndArea();
        }

        public static void Horizontal(this EditorWindow self, Action values, AlignMode mode = AlignMode.Default)
        {
            switch (mode)
            {
                case AlignMode.Center:
                    Center(self, () =>
                    {
                        EditorGUILayout.BeginHorizontal();
                        values?.Invoke();
                        EditorGUILayout.EndHorizontal();
                    });
                    break;
                case AlignMode.TopCenter:
                    Top(self, () =>
                    {
                        EditorGUILayout.BeginHorizontal();
                        values?.Invoke();
                        EditorGUILayout.EndHorizontal();
                    });
                    break;
                case AlignMode.Bottom:
                    Bottom(self, () =>
                    {
                        EditorGUILayout.BeginHorizontal();
                        values?.Invoke();
                        EditorGUILayout.EndHorizontal();
                    });
                    break;
                default:
                    EditorGUILayout.BeginHorizontal();
                    values?.Invoke();
                    EditorGUILayout.EndHorizontal();
                    break;
            }
        }

        public static void Vertical(this EditorWindow self, Action values, AlignMode mode = AlignMode.Default)
        {
            switch (mode)
            {
                case AlignMode.Center:
                    Center(self,() => 
                    {
                        EditorGUILayout.BeginVertical();
                        values?.Invoke();
                        EditorGUILayout.EndVertical();
                    });
                    break;
                case AlignMode.TopCenter:
                    Top(self, () =>
                    {
                        EditorGUILayout.BeginVertical();
                        values?.Invoke();
                        EditorGUILayout.EndVertical();
                    });
                    break;
                case AlignMode.Bottom:
                    Bottom(self, () =>
                    {
                        EditorGUILayout.BeginVertical();
                        values?.Invoke();
                        EditorGUILayout.EndVertical();
                    });
                    break;
                default:
                    EditorGUILayout.BeginVertical();
                    values?.Invoke();
                    EditorGUILayout.EndVertical();
                    break;
            }
        }

        public static void CheckArea(this EditorWindow self, Action area, Action ñallback)
        {
            EditorGUI.BeginChangeCheck();
            area?.Invoke();
            if (EditorGUI.EndChangeCheck())
            {
                ñallback?.Invoke();
            }
        }
    }

    public enum AlignMode
    {
        Default,
        TopCenter,
        Center,
        Bottom
    }
}
#endif