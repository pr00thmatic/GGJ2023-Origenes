using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cafetera : MonoBehaviour, IAmInteractive {
  public bool IsInteractive { get => true; }

  [Header("Information")]
  public ParticleSystem stream;

  [Header("Initialization")]
  public ParticleSystem waterStream;
  public ParticleSystem coffeeStream;
  public GameObject waterGlass;
  public GameObject coffeeGlass;

  void Update () {
    if (Input.GetMouseButtonDown(0) && Crosshair.Instance.selected &&
        Crosshair.Instance.selected.GetComponentInParent<Cafetera>() == this) {
      if (!Inventory.Instance.CurrentlyHeld) {
        stream.Play();
        (waterStream == stream? waterGlass: coffeeGlass).SetActive(true);
      } else if (Inventory.Instance.CurrentlyHeld.GetComponentInParent<HeldCoffee>()) {
        stream = coffeeStream;
        Inventory.Instance.Unhold();
        Inventory.Instance.Remove(Inventory.COFFEE_INDEX);
      }
    }
  }
}
