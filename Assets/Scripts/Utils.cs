using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utils {
  public static T[] Shuffle<T> (T[] arr) {
    for (int i=0; i<arr.Length; i++) {
      T tmp = arr[i];
      int randomIndex = Random.Range(i, arr.Length);
      arr[i] = arr[randomIndex];
      arr[randomIndex] = tmp;
    }

    return arr;
  }
}
