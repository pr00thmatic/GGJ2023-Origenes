using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crosshair : Singleton<Crosshair> {
  [Header("Information")]
  public GameObject selected;

  void Update () {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2f, Screen.height/2f));

    if (Physics.Raycast(ray, out hit)) {
      selected = hit.collider.gameObject;
    }
  }
}
