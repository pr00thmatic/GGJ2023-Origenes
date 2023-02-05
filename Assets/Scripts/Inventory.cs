using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : Singleton<Inventory> {
  [Header("Configuration")]
  public bool isVisible = false;

  [Header("Information")]
  public int heldIndex = -1;
  public Animator CurrentlyHeld {
    get => heldIndex < 0? null:
      heldItemsParent.GetChild(heldIndex).GetComponent<Animator>();
  }

  [Header("Initialization")]
  public Transform rotationPivot;
  public Transform heldItemsParent;
  public FPSControls fps;

  void Update () {
    if (Input.GetKeyDown(KeyCode.E)) {
      SetVisibility(!isVisible);
    }
    if (Input.GetMouseButtonDown(1)) {
      Unhold();
    }
  }

  public void Hold (int slotIndex) {
    foreach (Transform item in heldItemsParent) {
      item.GetComponent<Animator>().SetBool("being held", false);
    }
    heldIndex = slotIndex;

    CurrentlyHeld.SetBool("being held", true);
    SetVisibility(false);
  }

  public void Inspect () {
    FPSControls.Instance.enabled = false;
  }

  public void Unhold () {
    if (heldIndex < 0) return;
    CurrentlyHeld.SetBool("being held", false);
    heldIndex = -1;
  }

  public void SetVisibility (bool value) {
    isVisible = value;
    fps.enabled = !isVisible;
    fps.SetCursorLock(!isVisible);
  }
}
