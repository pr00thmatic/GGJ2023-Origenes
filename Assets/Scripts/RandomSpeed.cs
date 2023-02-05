using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSpeed : MonoBehaviour {
  [Header("Configuration")]
  public string parameter;
  public Vector2 range = new Vector2(0.5f, 1);

  [Header("Initialization")]
  public Animator animator;

  void Reset () {
    animator = GetComponent<Animator>();
  }

  void OnEnable () {
    animator.SetFloat(parameter, Random.Range(range.x,range.y));
  }
}
