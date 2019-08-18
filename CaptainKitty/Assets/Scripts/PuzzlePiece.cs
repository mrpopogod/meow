using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered the " + this.name);
        //if (other)
        if (other.name == "PuzzlePiece")
        {
            other.transform.position = this.transform.position;
            other.attachedRigidbody.mass = 1000;
        }
    }
}
