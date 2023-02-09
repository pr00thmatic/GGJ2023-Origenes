using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour {
  [Header("Initialization")]
  public FPSControls controls;
  public Inventory inventory;
  public Animator intro;

  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      intro.SetTrigger("start already");
      StartGame();
    }
  }

  public void StartGame () {
    controls.enabled = inventory.enabled = true;
  }
}
