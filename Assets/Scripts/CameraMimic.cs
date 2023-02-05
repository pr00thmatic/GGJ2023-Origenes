using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CameraMimic : MonoBehaviour {
  [Header("Initialization")]
  public Camera whoToMimic;
  public Camera mimicCamera;

  void Update () {
    mimicCamera.fieldOfView = whoToMimic.fieldOfView;
  }
}
