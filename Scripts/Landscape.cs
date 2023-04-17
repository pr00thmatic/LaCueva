using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Landscape : MonoBehaviour {
  // [Header("Configuration")]
  public static float maxDistance = 50;

  [Header("Initialization")]
  public Sprite frame;
  public Sprite content;

  void Update () {
    frame.color = content.color = Color.Lerp(Color.white, Color.black, (Camera.main.transform.position - transform.position).magnitude);
  }
}
