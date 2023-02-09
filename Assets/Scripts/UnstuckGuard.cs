using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnstuckGuard : MonoBehaviour {
  [Header("Configuration")]
  // public Hint[] hints = new Hint[] {
  public Hint searchCards = new Hint() {
    unlocker = "";
    clue = "¿Por dónde empiezo? Ya sé: debería consultar el fichero del primer piso.";
    timeToShow = ;
  };
  public Hint redeem = new Hint() {
    unlocker = "";
    clue = "Debería buscar el libro de esta ficha en la ventanilla del primer piso";
    timeToShow = ;
  };
  public Hint cluelessInitials = new Hint() {
    unlocker = "";
    clue = "¿Será que hay un autor con mi mismo nombre?";
    timeToShow = ;
  };
  public Hint iCantHoldAllThis = new Hint() {
    unlocker = "";
    clue = "Debería explorar el segundo piso";
    timeToShow = ;
  };
  public Hint misteriousPaper = new Hint() {
    unlocker = "";
    clue = "El libro que leí dejó caer un polvo raro al piso, debería ver qué es";
    timeToShow = ;
  };
  public Hint misteriousPowder = new Hint() {
    unlocker = "";
    clue = "¿Esto es café? qué raro... en el sótano hay una sala de conferencias y saben tener una cafetera...";
    timeToShow = ;
  };
  public Hint cupOfCoffee = new Hint() {
    unlocker = "";
    clue = "Al final no encontré nada sobre mi papá en la librería... no me voy a ir con las manos vacías, al menos podría ofrendar esto en el altar, por allí a alguno de mis ancestros le gusta."
    timeToShow = ;
  };

  void Start () {
    PlayUnlocker(searchCards);
  }

  public void HandleUnlocker (string unlocker) {
    
  }
}
