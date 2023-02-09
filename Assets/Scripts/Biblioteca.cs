using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Biblioteca : MonoBehaviour, IAmInteractive {
  public static bool blockShelf = false;

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
    blockShelf = false;
    booksList = rawBooks.ToString().Split("\n");
  }

  void Update () {
    if (IsInteractive && Input.GetMouseButtonDown(0) &&
        Crosshair.Instance.selected &&
        Crosshair.Instance.selected.GetComponentInParent<Biblioteca>() == this) {
      OpenTheBook();
      Inventory.Instance.Unhold();
      Inventory.Instance.Remove(Inventory.FICHA_INDEX);
      FPSControls.Instance.enabled = false;
    }
  }

  public void OpenTheBook () {
    Ficha ficha = Inventory.Instance.CurrentlyHeld.GetComponent<Ficha>();
    string bookTitle = ficha.codeField.text == "CEPO"? "Registro Conscriptos Servicio Militar\n1972-1973":
      booksList[Random.Range(0, booksList.Length)].Trim();
    theBook.Open(bookTitle, ficha.nameField.text, ficha.codeField.text == "CEPO");
    blockShelf = blockShelf || ficha.codeField.text == "CEPO";
  }
}
