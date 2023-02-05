using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PepeGrillo : Singleton<PepeGrillo> {
  [Header("Initialization")]
  public TextMeshProUGUI pepeGrillo;

  public static void Say (string message) {
    Instance.StopAllCoroutines();
    Instance.StartCoroutine(Instance._Speak(message)); } IEnumerator _Speak (string message) {

    Instance.pepeGrillo.text = message;
    yield return new WaitForSeconds(message.Split("\n").Length * 2);
    Instance.pepeGrillo.text = "";
  }
}
