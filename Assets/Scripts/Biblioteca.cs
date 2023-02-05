using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Biblioteca : MonoBehaviour, IAmInteractive {
  [Header("Information")]
  public string[] booksList;
  public bool IsInteractive { get =>
      Inventory.Has(Inventory.FICHA_INDEX) &&
      Inventory.IsBeingHeld(Inventory.FICHA_INDEX);
  }

  [Header("Initialization")]
  public TextAsset rawBooks;
  public TheBook theBook;

  void Awake () {
    booksList = rawBooks.ToString().Split("\n");
  }

  void Update () {
    if (IsInteractive && Input.GetMouseButtonDown(0)) {
      OpenTheBook();
      Inventory.Instance.Unhold();
      Inventory.Instance.Remove(Inventory.FICHA_INDEX);
      FPSControls.Instance.enabled = false;
    }
  }

  public void OpenTheBook () {
    theBook.Open(booksList[Random.Range(0, booksList.Length)].Trim(),
                 Inventory.Instance.CurrentlyHeld.GetComponent<Ficha>().nameField.text);
  }
}
