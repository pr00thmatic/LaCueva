using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(GenerateAlongSpline))]
public class GenerateAlongSplineEditor : Editor {
  GenerateAlongSpline Target { get => (GenerateAlongSpline) target; }

  public override void OnInspectorGUI () {
    DrawDefaultInspector();
    if (GUILayout.Button("generate!")) {
      Target.Generate();
      EditorSceneManager.MarkSceneDirty(Target.gameObject.scene);
    }
  }
}
