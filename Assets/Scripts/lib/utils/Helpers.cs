using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FuriLikeDodge {
  public static class Helpers
  {
    public static T GetComponentOrFail<T>(MonoBehaviour context)
    {
      T component = context.GetComponent<T>();

      if (component == null) throw new UnityException("Component could not be found");

      return component;
    }
  }
  
}
