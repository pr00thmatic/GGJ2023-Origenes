using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryTutorial : MonoBehaviour {
  [Header("Information")]
  public bool triggered = false;

  [Header("Initialization")]
  public GameObject tutorial;

  void Update () {
    if (!triggered && FPSControls.Instance.enabled) {
      triggered = true;
      StartCoroutine(_DisplayTutorial());
    }
  }

  IEnumerator _DisplayTutorial () {
    yield return new WaitForSeconds(3);
    tutorial.SetActive(true);
    while (true) {
      if (Inventory.Instance.isVisible) {
        Destroy(gameObject);
      }
      yield return null;
    }
  }
}
