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
  public AudioSource voice;

  void Update () {
    if (Input.GetMouseButtonDown(0) && Crosshair.Instance.selected &&
        Crosshair.Instance.selected.GetComponentInParent<Cafetera>() == this) {
      if (Inventory.Instance.CurrentlyHeld && Inventory.Instance.CurrentlyHeld.GetComponentInParent<HeldCoffee>()) {
        stream = coffeeStream;
        Inventory.Instance.Unhold();
        Inventory.Instance.Remove(Inventory.COFFEE_INDEX);
        PepeGrillo.Say("La cafetera está lista, ahora sí va a servir café en vez de solo agua caliente.");
        voice.Play();
      } else {
        sfx.PlayOneShot(sfx.clip);
        stream.Play();
        (waterStream == stream? waterGlass: coffeeGlass).SetActive(true);
        if (stream == coffeeGlass) this.enabled = false;
      }
    }
  }
}
