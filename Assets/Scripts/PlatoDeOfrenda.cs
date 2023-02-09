using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatoDeOfrenda : MonoBehaviour, IAmInteractive {
  [Header("Initialization")]
  public GameObject cinematicaRetrato;
  public AudioSource speaker;
  public AudioClip altar1;
  public AudioClip papa;
  public AudioClip crudo;
  public AudioClip no;
  public GameObject credits;

  public bool IsInteractive { get => true; }

  void Update () {
    if (Input.GetMouseButtonDown(0) && Crosshair.Instance.selected &&
        Crosshair.Instance.selected.GetComponent<PlatoDeOfrenda>() == this) {
      if (!Inventory.Instance.CurrentlyHeld) {
        PepeGrillo.Say("¿Tan rápido ya va ser todo santos? Aquí se le ponen ofrenda a las almas" +
                       " de los muertos, pero yo no sé si tenga alguna almita hambrienta");
        speaker.PlayOneShot(altar1);
      } else if (Inventory.Instance.CurrentlyHeld.GetComponentInParent<CupOfCoffeeHeld>()) {
        UnlockerTriggerer.Instance.enabled = false;
        PepeGrillo.Say("ay, papá... ojalá no te hayas muerto todavía...\n" +
                       "pero por si acaso, acá te lo dejo café... medio ch'uwa, " +
                       "pero eso nomás hay");
        speaker.PlayOneShot(papa);
        cinematicaRetrato.SetActive(true);
        FPSControls.Instance.enabled = false;
        Inventory.Instance.enabled = false;
        Crosshair.Instance.gameObject.SetActive(false);
        StartCoroutine(_Credits());
      } else if (Inventory.Instance.CurrentlyHeld.GetComponentInParent<HeldCoffee>()) {
        PepeGrillo.Say("¡no! ¿Cómo pues? ¿¿así café crudo??");
        speaker.PlayOneShot(crudo);
      } else {
        PepeGrillo.Say("ni yo quiero eso, mucho menos que un alma lo va a querer");
        speaker.PlayOneShot(no);
      }
    }
  }

  IEnumerator _Credits () {
    yield return new WaitForSeconds(35);
    credits.SetActive(true);
  }
}
