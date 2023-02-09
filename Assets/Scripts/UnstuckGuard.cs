using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnstuckGuard : MonoBehaviour {
  [Header("Information")]
  public Hint[] hints;

  void OnEnable () {
    UnlockerTriggerer.onUnlock += HandleUnlocker;
  }

  void OnDisable () {
    UnlockerTriggerer.onUnlock -= HandleUnlocker;
  }

  void Start () {
    hints = new Hint[] {
      new Hint() {
        voice = VoiceMaster.Instance.start,
        unlocker = "",
        clue = "¿Por dónde empiezo? Ya sé: debería consultar el fichero del primer piso.",
        timeToShow = 180
      },
      new Hint() {
        voice = VoiceMaster.Instance.ficha,
        unlocker = "ficha",
        clue = "Debería buscar el libro de esta ficha en la ventanilla del primer piso",
        timeToShow = 180
      },
      new Hint() {
        voice = VoiceMaster.Instance.cluelessInitials,
        unlocker = "cluelessInitials",
        clue = "¿Será que hay un autor con mi mismo nombre?",
        timeToShow = 180
      },
      new Hint() {
        voice = VoiceMaster.Instance.iCantHoldAllThisPowder,
        unlocker = "iCantHoldAllThisPowder",
        clue = "Debería explorar el segundo piso",
        timeToShow = 180
      },
      new Hint() {
        voice = VoiceMaster.Instance.paper,
        unlocker = "paper",
        clue = "Del libro que leí un polvo raro se cayó al piso, debería ver qué es",
        timeToShow = 180
      },
      new Hint() {
        voice = VoiceMaster.Instance.envelopedCoffee,
        unlocker = "envelopedCoffee",
        clue = "¿Esto es café? qué raro... en el sótano hay una sala de conferencias y saben tener una cafetera...",
        timeToShow = 180
      },
      new Hint() {
        voice = VoiceMaster.Instance.cupOfCoffee,
        unlocker = "cupOfCoffee",
        clue = "Al final no encontré nada sobre mi papá en la librería... " +
        "no me voy a ir con las manos vacías, al menos podría ofrendar café en el" +
        "altar, por allí a alguno de mis ancestros le gusta.",
        timeToShow = 180
      }
    };

    PlayUnlocker(hints[0]);
  }

  public void HandleUnlocker (string unlocker) {
    if (unlocker == "") return;

    foreach (Hint hint in hints) {
      if (hint.unlocker == unlocker) {
        PlayUnlocker(hint);
        return;
      }
    }

    Debug.LogWarning("I don't have an unlocker for this " + unlocker);
  }

  public void PlayUnlocker (Hint hint) {
    StopAllCoroutines();
    StartCoroutine(_PlayUnlocker(hint));
  }
  IEnumerator _PlayUnlocker (Hint hint) {
    while (true) {
      float elapsed = 0;

      while (elapsed <= hint.timeToShow) {
        elapsed += Time.deltaTime;
        yield return null;
      }

      if (hint.unlocker != "paper" ||
          (hint.unlocker == "paper" && (UnlockerTriggerer.unlocked.ContainsKey("iCantHoldAllThisPowder")))) {
        PepeGrillo.Say(hint.clue);
        VoiceMaster.Speak(hint.voice);
      }
    }
  }
}
