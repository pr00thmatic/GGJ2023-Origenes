using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Acquire : MonoBehaviour, IAmInteractive {
  [Header("Configuration")]
  public bool unnacquirable = false;
  public Animator needsToBeGrabbable;
  [TextArea]
  public string errorMessage;
  public AudioClip errorVoice;
  [TextArea]
  public string successMessage;
  public AudioClip successVoice;
  public string unlocker;

  // [Header("Information")]
  public bool IsInteractive { get => true; }

  [Header("Initialization")]
  public Transform held;
  public InventorySlot slot;

  void Update () {
    if (Input.GetMouseButtonDown(0) && Crosshair.Instance.selected &&
        Crosshair.Instance.selected.GetComponentInParent<Acquire>() == this) {
      if (!unnacquirable && Inventory.Instance.CurrentlyHeld == needsToBeGrabbable) {
        AcquireSelf();
      } else {
        if (errorMessage == "" && !needsToBeGrabbable) {
          VoiceMaster.Speak(VoiceMaster.Instance.noPuedoUsar);
          PepeGrillo.Say("No puedo usar esto. Mejor lo guardo");
          Inventory.Instance.Unhold();
        } else {
          PepeGrillo.Say(errorMessage);
          VoiceMaster.Speak(errorVoice);
        }
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
    if (successMessage.Length > 0) {
      PepeGrillo.Say(successMessage);
      VoiceMaster.Speak(successVoice);
    }
    if (unlocker != "") {
      UnlockerTriggerer.TriggerUnlocker(unlocker);
    }
  }
}
