using UnityEngine;
using Unity.Mathematics;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Splines;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class GenerateAlongSpline : MonoBehaviour {
  [Header("Configuration")]
  public float distance = 10;

  [Header("Initialization")]
  public SplineContainer spline;
  public Transform folder;
  public GameObject prototype;

  void OnEnable () {
    if (!spline || !prototype) return;
    CleanFolder();
    float splineLength = spline.CalculateLength();

    for (float d = 0; d<splineLength; d += distance) {
      #if UNITY_EDITOR
      GameObject generated = Application.isPlaying?
        Instantiate(prototype): (PrefabUtility.InstantiatePrefab(prototype)) as GameObject;
      #else
      GameObject generated = Instantiate(prototype);
      #endif
      generated.transform.parent = folder;
      spline.Evaluate(0, d/splineLength, out float3 position, out float3 tangent, out float3 upVector);
      generated.transform.position = position;
      generated.transform.forward = (Vector3) tangent;
    }
  }

  public void CreateFolder () {
    folder = new GameObject("GeneratedAlongSpline").transform;
    folder.parent = transform;
    folder.position = Vector3.zero;
    folder.rotation = Quaternion.identity;
  }

  public void CleanFolder () {
    if (Application.isPlaying) Destroy(folder.gameObject);
    else DestroyImmediate(folder.gameObject);
    CreateFolder();
  }
}
