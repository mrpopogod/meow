using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverState : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Entered the river");
            other.GetComponent<Cat>().EnteredRiver();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Left the river");
            other.GetComponent<Cat>().LeftRiver();
        }
    }
}
