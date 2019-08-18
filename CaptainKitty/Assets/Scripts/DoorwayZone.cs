using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered the " + this.name);
        if (other != null)
        {
            //((Cat)other).movement
        }
    }
}
