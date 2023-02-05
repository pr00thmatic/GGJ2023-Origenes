using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Acquire : MonoBehaviour, IAmInteractive {
  [Header("Configuration")]
  public Animator needsToBeGrabbable;
  [TextArea]
  public string errorMessage;
  [TextArea]
  public string successMessage;

  // [Header("Information")]
  public bool IsInteractive { get => true; }

  [Header("Initialization")]
  public Transform held;
  public InventorySlot slot;

  void Update () {
    if (Input.GetMouseButtonDown(0) && Crosshair.Instance.selected.GetComponentInParent<Acquire>() == this) {
      if (Inventory.Instance.CurrentlyHeld == needsToBeGrabbable) {
        AcquireSelf();
      } else {
        PepeGrillo.Say(errorMessage);
      }
    }
  }

  public void AcquireSelf () {
    if (needsToBeGrabbable) {
      Inventory.Instance.Remove(needsToBeGrabbable.transform.GetSiblingIndex());
    }

    gameObject.SetActive(false);
    Inventory.Instance.Hold(held.GetSiblingIndex());
    slot.IsAcquired = true;
    if (successMessage.Length > 0) PepeGrillo.Say(successMessage);
  }
}
