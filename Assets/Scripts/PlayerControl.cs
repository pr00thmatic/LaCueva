using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
  [Header("Configuration")]
  public float maxSpeed = 25;

  [Header("Initialization")]
  public MoveAlongSpline mover;

  void Update () {
    // no need of delta time because we are providing speed and not delta motion
    mover.speed = Input.GetAxis("Vertical") * maxSpeed;
  }
}
