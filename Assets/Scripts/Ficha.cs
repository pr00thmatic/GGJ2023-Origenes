using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Ficha : MonoBehaviour {
  [Header("Information")]
  public string[] namesList;
  public string[] lastNamesList;
  public string[] anxientNamesList;

  [Header("Initialization")]
  public TextMeshPro codeField;
  public TextMeshPro nameField;
  public TextAsset namesSource;
  public TextAsset lastNamesSource;
  public TextAsset hailSatan;
  public InventorySlot fichaSlot;

  void Awake () {
    namesList = namesSource.ToString().Split("\n");
    lastNamesList = lastNamesSource.ToString().Split("\n");
    anxientNamesList = hailSatan.ToString().Split("\n");
  }

  void OnEnable () {
  }

  public bool Search (string code) {
    FPSControls.Instance.enabled = true;

    if (code.Length < 4) {
      gameObject.SetActive(false);
      return false;
    }

    code = code.ToUpper();
    gameObject.SetActive(true);
    codeField.text = code;

    if (code == "CEPO") {
      nameField.text = "César Eruberto Paucara Ojopi";
    } else {
      nameField.text = GimmieItem(code[0], namesList);
      nameField.text += " " + GimmieItem(code[1], namesList);
      nameField.text += " " + GimmieItem(code[2], lastNamesList);
      nameField.text += " " + GimmieItem(code[3], lastNamesList);
    }

    Inventory.Instance.Hold(transform.GetSiblingIndex());
    fichaSlot.IsAcquired = true;
    return true;
  }

  string GimmieItem (char startsWith, string[] array) {
    try {
      Utils.Shuffle(namesList);
      Utils.Shuffle(lastNamesList);
      startsWith = (startsWith + "").ToUpper()[0];
      foreach (string item in array) {
        if (item.Trim().Length == 0) continue;
        if (item.ToUpper()[0] == startsWith) {
          return item.Trim();
        }
      }
    } catch {}

    return anxientNamesList[Random.Range(0, anxientNamesList.Length)].Trim();
  }
}
