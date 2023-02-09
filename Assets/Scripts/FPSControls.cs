using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSControls : Singleton<FPSControls> {
  [Header("Configuration")]
  public float speed;
  public Vector2 xRotationRange = new Vector2(-60, 50);
  public Vector2 sensitivity = new Vector2(1, 1);

  [Header("Information")]
  public float xRotation = 0;

  [Header("Initialization")]
  public Transform verticalPivot;
  public Transform horizontalPivot;
  public SmoothVolume steps;

  void OnEnable () {
    SetCursorLock(true);
    Inventory.Instance.enabled = true;
  }

  void OnDisable () {
    steps.targetVolume = 0;
  }

  void Update () {
    verticalPivot.Rotate(0, Input.GetAxis("Mouse X") * sensitivity.x, 0);
    xRotation = Mathf.Clamp(xRotation + sensitivity.y * Input.GetAxis("Mouse Y"),
                            xRotationRange.x, xRotationRange.y);
    horizontalPivot.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

    Vector3 motionDirection = (Input.GetAxis("Horizontal") * verticalPivot.transform.right +
                               Input.GetAxis("Vertical") * verticalPivot.transform.forward);
    transform.position += motionDirection * speed * Time.deltaTime;

    steps.targetVolume = motionDirection.magnitude < 0.1f? 0: 0.4f;
  }

  public void SetCursorLock (bool value) {
    Cursor.lockState = value? CursorLockMode.Locked: CursorLockMode.None;
    Cursor.visible = !value;
  }
}
