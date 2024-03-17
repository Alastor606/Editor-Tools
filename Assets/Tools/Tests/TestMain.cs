#if UNITY_EDITOR
namespace EditorTools
{
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
            this.Vertical(() =>
            {
                Draw.Label("Test label", 25, Color.green, Space:20);
                Draw.TextField(ref _testString);
                Draw.ObjectField(ref obj, allowSceneObjects: true);
                Draw.Button("Chec button", () => Debug.Log("Button pressed"));
                _testBool.Field("Test bool", true);

            },AlignMode.Center);
           
        }
    }
}
#endif