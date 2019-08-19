using System;
using UnityEngine;

public class ZoneBoundary : MonoBehaviour
{
  public enum Zone
  {
    River,
    Desert,
    Forest,
    Plains,
    Starting
  }

  [SerializeField] public Zone zone;

  public string Name
  {
    get
    {
      return Enum.GetName(typeof(Zone), zone);
    }
  }
}
