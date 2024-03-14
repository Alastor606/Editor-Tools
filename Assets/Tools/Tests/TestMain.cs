namespace EditorTools
{
    using UnityEditor;
    using UnityEngine;

    public class TestMain : EditorWindow
    {
        int _testInt;
        float _testFloat;
        string _testString;
        GameObject obj;
        bool _testBool;
        [MenuItem("Test/Main")]
        public static void CreateWindow() 
        {
            GetWindow<TestMain>("Tester").minSize = new(400, 475);
        }

        private void OnGUI()
        {
            Draw.Label("Ahaha", 25, Color.green);
            _testInt.Field("TestInt", 10).Space(50);
            _testFloat.Field("Test float", 50);
            Draw.TextField(ref _testString);
            Draw.ObjectField(ref obj, allowSceneObjects: true);
            Draw.Button("Chec button", () => Debug.Log("ahah"));
            _testBool.Field("Test bool", true);
            
        }
    }
}

 