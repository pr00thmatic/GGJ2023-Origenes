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
  public AudioSource sfx;

  void Update () {
    if (Input.GetMouseButtonDown(0) && Crosshair.Instance.selected &&
        Crosshair.Instance.selected.GetComponentInParent<Cafetera>() == this) {
      if (!Inventory.Instance.CurrentlyHeld) {
        sfx.PlayOneShot(sfx.clip);
        stream.Play();
        (waterStream == stream? waterGlass: coffeeGlass).SetActive(true);
        if (stream == coffeeGlass) this.enabled = false;
      } else if (Inventory.Instance.CurrentlyHeld.GetComponentInParent<HeldCoffee>()) {
        stream = coffeeStream;
        Inventory.Instance.Unhold();
        Inventory.Instance.Remove(Inventory.COFFEE_INDEX);
      }
    }
  }
}
