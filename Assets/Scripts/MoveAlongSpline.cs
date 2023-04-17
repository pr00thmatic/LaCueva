using UnityEngine;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Splines;

[ExecuteInEditMode]
public class MoveAlongSpline : MonoBehaviour {
  [Header("Configuration")]
  public float speed;

  [Header("Information")]
  public float t;
  public float length;

  [Header("Initialization")]
  public SplineContainer spline;
  public Transform target;

  void Reset () {
    target = transform;
    spline = GameObject.FindObjectOfType<SplineContainer>();
  }

  void OnEnable () {
    SnapToSpline();
  }

  void Update () {
    #if UNITY_EDITOR
    if (!Application.isPlaying) {
      SnapToSpline();
    } else {
    #endif

      if (t > 1) return;

      length = spline.CalculateLength(); // in case spline changes
      t += (speed * Time.deltaTime) / length;

      spline.Evaluate(0, t, out float3 position, out float3 tangent, out float3 upVector3);
      target.position = (Vector3) position;
      target.forward = (Vector3) tangent;
    #if UNITY_EDITOR
    }
    #endif
  }

  public void SnapToSpline () {
    SplineUtility.GetNearestPoint(spline.Splines[0], (float3) target.position, out float3 nearest, out t);
    if ((target.position - (Vector3) nearest).magnitude > 0.1f) {
      target.position = (Vector3) nearest;
    }
    target.forward = (Vector3) spline.EvaluateTangent(0, t);
  }
}
