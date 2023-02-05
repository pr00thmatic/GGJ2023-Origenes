using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TheBook : MonoBehaviour {
  [Header("Initialization")]
  public TextMeshPro title;
  public TextMeshPro author;

  public void Open (string title, string author) {
    gameObject.SetActive(true);
    this.title.text = title;
    StartCoroutine(_Open());
  }

  IEnumerator _Open () {
    yield return new WaitForSeconds(5);
  }
}
