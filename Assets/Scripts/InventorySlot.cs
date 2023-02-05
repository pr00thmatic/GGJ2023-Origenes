using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour {
  public static event System.Action<int> onHoldRequest;

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
    onHoldRequest?.Invoke(this.transform.GetSiblingIndex());
  }
}
