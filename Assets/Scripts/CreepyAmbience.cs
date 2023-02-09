using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreepyAmbience : MonoBehaviour {
  [Header("Information")]
  public float seed = 0;
  public float animatorSeed = 0;

  [Header("Initialization")]
  public Animator animator;
  public SmoothVolume speaker;

  void OnEnable () {
    seed = Random.Range(0,1f);
    animatorSeed = Random.Range(0,1f);
  }

  void Update () {
    speaker.targetVolume = Mathf.PerlinNoise(Time.time * 0.5f, seed) * 0.5f;
    animator.SetFloat("time", Mathf.PerlinNoise(Time.time * 0.25f, animatorSeed));
  }
}
