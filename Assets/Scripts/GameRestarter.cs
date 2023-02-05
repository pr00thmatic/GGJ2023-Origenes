using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameRestarter : MonoBehaviour {
  void Update () {
    if (Input.GetKeyDown(KeyCode.Delete)) {
      SceneManager.LoadScene(gameObject.scene.name);
    }
  }
}
