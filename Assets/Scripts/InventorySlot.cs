using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour {
  [Header("Configuration")]
  public bool available = true;

  // [Header("Information")]
  public bool Visible { get => Inventory.Instance.isVisible; }
  public bool IsAcquired { get => !available; set => available = !value; }

  [Header("Initialization")]
  public Animator open;
  public Animator closed;

  void Update () {
    if (open.enabled) open.gameObject.SetActive(available);
    if (closed.enabled) closed.gameObject.SetActive(!available);

    if (open.enabled) open.SetBool("visible", Visible);
    if (closed.enabled) closed.SetBool("visible", Visible);
  }

  public void HoldTheItem () {
    Inventory.Instance.Hold(this.transform.GetSiblingIndex());
  }
}
