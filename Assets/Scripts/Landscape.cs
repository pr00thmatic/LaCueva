using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Landscape : MonoBehaviour {
  // [Header("Configuration")]
  public float maxDistance { get => GetComponentInParent<LandscapeSettings>().maxDistance; }
  public float minDistance { get => GetComponentInParent<LandscapeSettings>().minDistance; }

  [Header("Information")]
  public float t;

  [Header("Initialization")]
  public SpriteRenderer frame;
  public SpriteRenderer content;

  void OnEnable () {
    content.flipX = Random.Range(0,1f) < 0.5;
  }

  void Update () {
    if (frame && content) {
      t = ((Camera.main.transform.position - transform.position).magnitude - minDistance) /
        (maxDistance - minDistance);
      frame.color = content.color = Color.Lerp (Color.white, Color.black, t);
    }
  }
}
