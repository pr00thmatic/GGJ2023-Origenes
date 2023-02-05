using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour {
  [Header("Configuration")]
  public bool available = true;
  public bool Visible { get => Inventory.Instance.isVisible; }

  [Header("Initialization")]
  public Animator open;
  public Animator closed;

  void Update () {
    open.gameObject.SetActive(available);
    closed.gameObject.SetActive(!available);

    open.SetBool("visible", Visible);
    closed.SetBool("visible", Visible);
  }

  public void HoldTheItem () {
    Inventory.Instance.Hold(this.transform.GetSiblingIndex());
  }
}
