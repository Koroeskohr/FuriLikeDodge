using UnityEngine;

namespace FuriLikeDodge
{
  public struct NormalizedVector
  {
    private readonly Vector3 _value;

    public NormalizedVector(Vector3 v)
    {
      _value = v.normalized;
    }

    public Vector3 Value { get { return _value; } }
    public override string ToString()
    {
      return _value.ToString();
    }
  }
}