using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour {
  [Header("Initialization")]
  public FPSControls controls;
  public Inventory inventory;

  public void StartGame () {
    controls.enabled = inventory.enabled = true;
  }
}
