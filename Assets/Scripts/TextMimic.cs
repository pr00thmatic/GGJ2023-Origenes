using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[ExecuteInEditMode]
public class TextMimic : MonoBehaviour {
  [Header("Initialization")]
  public TextMeshPro whoToMimic;
  public TextMeshPro mimic;

  void Reset () {
    mimic = GetComponent<TextMeshPro>();
  }

  void Update () {
    if (whoToMimic) mimic.text = whoToMimic.text;
  }
}
