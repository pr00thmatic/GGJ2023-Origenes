using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Ficha : MonoBehaviour {
  [Header("Information")]
  public string[] namesList;
  public string[] lastNamesList;

  [Header("Initialization")]
  public TextMeshPro codeField;
  public TextMeshPro nameField;
  public TextAsset namesSource;
  public TextAsset lastNamesSource;
  public InventorySlot fichaSlot;

  void Awake () {
    namesList = namesSource.ToString().Split("\n");
    lastNamesList = lastNamesSource.ToString().Split("\n");
  }

  void OnEnable () {
    Utils.Shuffle(namesList);
    Utils.Shuffle(lastNamesList);
  }

  public void Search (string code) {
    gameObject.SetActive(true);
    codeField.text = code.ToUpper();
    nameField.text = GimmieItem(code[0], namesList);
    nameField.text += " " + GimmieItem(code[1], namesList);
    nameField.text += " " + GimmieItem(code[2], lastNamesList);
    nameField.text += " " + GimmieItem(code[3], lastNamesList);
    FPSControls.Instance.enabled = true;
    Inventory.Instance.Hold(transform.GetSiblingIndex());
    fichaSlot.available = false;
  }

  string GimmieItem (char startsWith, string[] array) {
    startsWith = (startsWith + "").ToUpper()[0];
    foreach (string item in array) {
      if (item.ToUpper()[0] == startsWith) {
        return item.Trim();
      }
    }

    return "Lucifer";
  }
}
