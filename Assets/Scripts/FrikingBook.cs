using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FrikingBook : MonoBehaviour {
  [Header("Configuration")]
  public bool isAFrikingBook = false;
  public float portadaTime = 3;

  [Header("Initialization")]
  public Animator animator;
  public ParticleSystem coffeeMaybe;
  public GameObject content;
  public GameObject coffeePile;

  void OnEnable () { StartCoroutine(_Open()); } IEnumerator _Open () {
    yield return new WaitForSeconds(portadaTime);
    animator.SetTrigger("next");
    if (isAFrikingBook) {
      yield return new WaitForSeconds(0.5f);
      content.SetActive(true);
    }
    yield return new WaitForSeconds(isAFrikingBook? 5: 2);
    if (isAFrikingBook) {
      coffeeMaybe.Play();
      yield return new WaitForSeconds(2);
    }
    animator.SetTrigger("next");
    if (isAFrikingBook) {
      yield return new WaitForSeconds(0.5f);
      content.SetActive(false);
      coffeePile.SetActive(true);
      coffeePile.transform.parent = null;
    }
    yield return new WaitForSeconds(2);

    GetComponentInParent<TheBook>().Close();
  }
}
