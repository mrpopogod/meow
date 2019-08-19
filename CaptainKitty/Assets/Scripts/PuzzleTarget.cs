using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTarget : MonoBehaviour
{
    public GameObject piece = null;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered the " + this.name);
        Debug.Log(other.name + " has entered the " + this.name);
        //if (other)
        if (other.gameObject == piece)
        {
            Debug.Log(other.name + "is my piece..." + this.name);
            other.transform.position = this.transform.position;
            other.attachedRigidbody.mass = 1000;
        }
    }
}
