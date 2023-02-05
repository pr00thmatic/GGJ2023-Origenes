using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimedParameter : MonoBehaviour {
  [Header("Initialization")]
  public string parameterName = "time";
  public Animator animator;

  void Reset () {
    animator = GetComponent<Animator>();
  }

  void Update () {
    animator.SetFloat(parameterName, Time.time % 1);
  }
}
