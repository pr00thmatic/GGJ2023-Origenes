using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PepeGrillo : Singleton<PepeGrillo> {
  [Header("Initialization")]
  public TextMeshProUGUI pepeGrillo;

  [Header("Information")]
  public bool isSayingSomething = false;

  public static void Say (string message) {
    Instance.isSayingSomething = true;
    Instance.StopAllCoroutines();
    Instance.StartCoroutine(Instance._Speak(message)); } IEnumerator _Speak (string message) {

    Instance.pepeGrillo.text = message;
    yield return new WaitForSeconds(message.Split(" ").Length * 0.3f);
    Instance.isSayingSomething = false;
    Instance.pepeGrillo.text = "";
  }
}
