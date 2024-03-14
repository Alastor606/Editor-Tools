namespace EditorTools
{
    using UnityEditor;
    using UnityEngine;

    public class TestMain : EditorWindow
    {
        private string _testString;
        private GameObject obj;
        private bool _testBool;
        [MenuItem("Test/Main")]
        public static void CreateWindow()  =>
            GetWindow<TestMain>("Tester").minSize = new(400, 475);
        

        private void OnGUI()
        {
            Align.Horizontal(() =>
            {
                Draw.Label("Test label", 25, Color.green);
                Draw.TextField(ref _testString);
                Draw.ObjectField(ref obj, allowSceneObjects: true);
                Draw.Button("Chec button", () => Debug.Log("Button pressed"));
                _testBool.Field("Test bool", true);

            });
           
        }
    }
}

 