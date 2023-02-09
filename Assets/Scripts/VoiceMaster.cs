using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoiceMaster : Singleton<VoiceMaster> {
  [Header("Configuration")]
  public AudioClip noPuedoUsar;
  public AudioClip start;
  public AudioClip ficha;
  public AudioClip cluelessInitials;
  public AudioClip iCantHoldAllThisPowder;
  public AudioClip paper;
  public AudioClip envelopedCoffee;
  public AudioClip cupOfCoffee;

  [Header("Initialization")]
  public AudioSource speaker;

  public static void Speak (AudioClip clip) {
    Instance.speaker.PlayOneShot(clip);
  }
}
