using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
  protected static T _instance;

  public static T Instance {
    get {
      if (!_instance) {
        _instance = GameObject.FindObjectOfType<T>(true);
      }

      return _instance;
    }
  }

  protected virtual void Awake () {
    if (Instance != this) {
      Destroy(gameObject);
    }
  }
}
