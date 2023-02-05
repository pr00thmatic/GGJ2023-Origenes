using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecordShelf : MonoBehaviour {
  [Header("Initialization")]
  public GameObject formularioBusqueda;

  void Update () {
    if (Input.GetMouseButtonDown(0) && FPSControls.Instance.enabled &&
        Crosshair.Instance.selected.GetComponentInParent<RecordShelf>() == this) {
      formularioBusqueda.SetActive(true);
      FPSControls.Instance.enabled = false;
    }
  }
}
