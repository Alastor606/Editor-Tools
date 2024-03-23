#if UNITY_EDITOR
namespace EditorTools
{
    using Unity.VisualScripting;
    using UnityEditor;
    using UnityEngine;

    public class TestMain : EditorWindow
    {
        private string _testString;
        private GameObject obj;
        private bool _testBool;
        [MenuItem("Test/123")]
        public static void CreateWindow()
        {
            var window = GetWindow<TestMain>("Tester");
            window.Settings();
            window.minSize = new(400, 475);
        }

        private void OnGUI()
        {
           
        }
    }
}
#endif