using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TheBook : MonoBehaviour {
  [Header("Configuration")]
  public float readingTime = 3;
  public float waitBeforePouring = 2;

  [Header("Initialization")]
  public TextMeshPro title;
  public TextMeshPro author;
  public GameObject frikingBook;
  public GameObject normalBook;

  public void Open (string title, string author, bool frikingOpenIt = false) {
    gameObject.SetActive(true);
    this.title.text = title;
    this.author.text = author;
    if (frikingOpenIt) {
      frikingBook.SetActive(true);
    }
  }

  public void Close () {
    gameObject.SetActive(false);
    FPSControls.Instance.enabled = true;
  }
}
