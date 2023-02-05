using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class FormularioDeBusqueda : MonoBehaviour {
  [Header("Initialization")]
  public TMP_InputField input;
  public Animator fadeInOut;
  public Ficha ficha;

  void OnEnable () { StartCoroutine(_OnEnable()); }
  IEnumerator _OnEnable () {
    Crosshair.Instance.gameObject.SetActive(false);
    fadeInOut.SetTrigger("show up");
    Inventory.Instance.enabled = false;
    yield return null;
    input.ActivateInputField();
  }

  public void SearchFicha () { StartCoroutine(_SearchFicha()); }
  IEnumerator _SearchFicha () {
    fadeInOut.SetTrigger("gtfo");
    yield return new WaitForSeconds(1);
    ficha.Search(input.text);
    Crosshair.Instance.gameObject.SetActive(true);
    gameObject.SetActive(false);
  }
}
