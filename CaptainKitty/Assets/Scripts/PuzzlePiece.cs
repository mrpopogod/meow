using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public GameObject target = null;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has run into " + this.name);
        //if (other)
        if (other == target)
        {
            Debug.Log(this.name + " has found it's home in " + other.name);
            //other.transform.position = this.transform.position;
            //other.attachedRigidbody.mass = 1000;
        }
    }
}
