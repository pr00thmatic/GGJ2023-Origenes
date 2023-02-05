using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : Singleton<Inventory> {
  public const int CI_INDEX = 0;
  public const int FICHA_INDEX = 1;

  [Header("Configuration")]
  public bool isVisible = false;
  public float sensitivity = 5;

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
  public Transform slotsParent;

  void Update () {
    if (Input.GetKeyDown(KeyCode.E)) {
      SetVisibility(!isVisible);
    }
    if (Input.GetMouseButtonDown(1)) {
      rotationPivot.rotation = Quaternion.identity;
      Unhold();
    }
    if (Input.GetMouseButton(2)) {
      Inspect();
    }
    if (Input.GetMouseButtonUp(2)) {
      FPSControls.Instance.enabled = true;
    }
  }

  public static bool Has (int index) {
    return Instance.slotsParent.GetChild(index).GetComponent<InventorySlot>().IsAcquired;
  }

  public static bool IsBeingHeld (int index) {
    return Instance.heldIndex == index;
  }

  public void Remove (int index) {
    slotsParent.GetChild(index).GetComponent<InventorySlot>().IsAcquired = false;
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
    rotationPivot.rotation = rotationPivot.rotation *
      Quaternion.Euler((Vector3.right * Input.GetAxis("Mouse Y") +
                        Vector3.up * Input.GetAxis("Mouse X")) * sensitivity);
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
