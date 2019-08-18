using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayZone : MonoBehaviour
{

    [SerializeField] GameObject zoneBoundary;
    private ZoneBoundary boundary;

    private void Awake()
    {
        boundary = zoneBoundary.GetComponent<ZoneBoundary>();
    }

    public void OnTriggerEnter(Collider other)
      {
          Debug.Log($"{other.name} has crossed the {this.boundary.Name} doorway");
          if (other != null)
          {
              //((Cat)other).movement
          }
      }
}
