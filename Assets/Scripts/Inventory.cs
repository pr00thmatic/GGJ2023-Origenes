using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : Singleton<Inventory> {
  [Header("Configuration")]
  public bool isVisible = false;

  [Header("Initialization")]
  public Transform rotationPivot;
  public Transform heldItemsParent;
  public FPSControls fps;

  void OnEnable () {
    InventorySlot.onHoldRequest += HandleHoldRequest;
  }

  void OnDisable () {
    InventorySlot.onHoldRequest -= HandleHoldRequest;
  }

  void Update () {
    if (Input.GetKeyDown(KeyCode.E)) {
      isVisible = !isVisible;
      fps.enabled = !isVisible;
      fps.SetCursorLock(!isVisible);
    }
  }

  public void HandleHoldRequest (int slotIndex) {
    foreach (Transform item in heldItemsParent) {
      item.GetComponent<Animator>().SetBool("being held", false);
    }
    heldItemsParent.GetChild(slotIndex).GetComponent<Animator>().SetBool("being held", true);  }
}
