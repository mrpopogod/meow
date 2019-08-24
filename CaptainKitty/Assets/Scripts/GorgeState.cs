using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorgeState : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Entered the gorge");
            other.GetComponent<Cat>().EnteredGorge();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Left the gorge");
            other.GetComponent<Cat>().LeftGorge();
        }
    }
}
