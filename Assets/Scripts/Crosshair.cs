using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crosshair : Singleton<Crosshair> {
  [Header("Configuration")]
  public float distanceToInteract = 3;
  public float inspectTutorialTime = 10;

  [Header("Information")]
  public GameObject selected;
  public float elapsedHoldingAnItem = 0;
  public int TutorialStatus {
    get => animator.GetBool("is over interactive")? 2:
      Inventory.Instance.CurrentlyHeld && elapsedHoldingAnItem < inspectTutorialTime? 1: 0;
  }

  [Header("Initialization")]
  public Animator animator;
  public Animator tutorialAnimator;

  void Update () {
    if (Inventory.Instance.CurrentlyHeld) elapsedHoldingAnItem += Time.deltaTime;

    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2f, Screen.height/2f));

    if (Physics.Raycast(ray, out hit, distanceToInteract)) {
      selected = hit.collider.gameObject;
    } else {
      selected = null;
    }
    animator.SetBool("is over interactive", selected &&
                     selected.GetComponentInParent<IAmInteractive>() != null &&
                     selected.GetComponentInParent<IAmInteractive>().IsInteractive);
    tutorialAnimator.SetInteger("tutorial status", TutorialStatus);
  }
}
