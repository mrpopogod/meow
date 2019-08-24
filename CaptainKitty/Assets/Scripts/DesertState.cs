using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertState : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Entered the desert");
            other.GetComponent<Cat>().EnteredDesert();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Left the desert");
            other.GetComponent<Cat>().LeftDesert();
        }
    }
}
