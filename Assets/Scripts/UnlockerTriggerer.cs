using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnlockerTriggerer : Singleton<UnlockerTriggerer> {
  public static event System.Action<string> onUnlock;
  public static void TriggerUnlocker (string unlocker) {
    if (unlocked.ContainsKey(unlocker)) return;
    onUnlock?.Invoke(unlocker);
  }

  public static Dictionary<string, bool> unlocked = new Dictionary<string, bool>();

  void OnEnable () {
    unlocked = new Dictionary<string, bool>();
  }
}
