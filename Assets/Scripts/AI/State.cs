using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
  public event System.Action<State> onExit;

  void OnEnable () {
    foreach (Transform brother in transform.parent) {
      if (brother.GetComponent<State>() && brother.gameObject.activeSelf && brother != transform) {
        brother.gameObject.SetActive(false);
      }
    }
  }

  void OnDisable () {
    if (!this.enabled) return;
    onExit?.Invoke(this);
  }

  public void Next () {
    transform.parent.GetChild(transform.GetSiblingIndex()+1).gameObject.SetActive(true);
  }

  public void Activate () {
    Transform parent = transform;
    do {
      parent.gameObject.SetActive(true);
      parent = parent.parent;
    } while (parent);
  }
}
