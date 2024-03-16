#if UNITY_EDITOR
namespace EditorTools
{
    using System;
    using UnityEditor;
    public class SettingsWindow : EditorWindow
    {
        private EditorWindow _currentWindow;
        private string _name;
        [Obsolete]
        public void Init(EditorWindow w)
        {
            _currentWindow = w;
            _name = _currentWindow.title;
        }
            

        private void OnGUI()
        {
            _currentWindow.title = Draw.TextField(ref _name, "Name field");
        }
    }
}

#endif