using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmoothVolume : MonoBehaviour {
  [Header("Configuration")]
  public float targetVolume;
  public float speed = 4;

  // [Header("Information")]
  public float CurrentVolume { get => speaker.volume; set => speaker.volume = value; }

  [Header("Initialization")]
  public AudioSource speaker;

  void Reset () {
    speaker = GetComponent<AudioSource>();
    if (!speaker) speaker = gameObject.AddComponent<AudioSource>();
  }

  void Update () {
    CurrentVolume = Mathf.MoveTowards(CurrentVolume, targetVolume, speed * Time.deltaTime);
  }
}
