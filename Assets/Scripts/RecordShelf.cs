using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecordShelf : MonoBehaviour, IAmInteractive {
  // [Header("Information")]
  public bool IsInteractive { get => !Inventory.Has(Inventory.FICHA_INDEX) && !Biblioteca.blockShelf; }

  [Header("Initialization")]
  public GameObject formularioBusqueda;

  void Update () {
    if (Input.GetMouseButtonDown(0) && IsInteractive && FPSControls.Instance.enabled &&
        Crosshair.Instance.selected &&
        Crosshair.Instance.selected.GetComponentInParent<RecordShelf>() == this) {
      formularioBusqueda.SetActive(true);
      FPSControls.Instance.enabled = false;
    }
  }
}
