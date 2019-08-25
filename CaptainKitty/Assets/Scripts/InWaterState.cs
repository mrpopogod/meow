using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWaterState : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Entered the water");
            other.GetComponent<Cat>().EnteredWater();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Left the water");
            other.GetComponent<Cat>().LeftWater();
        }
    }
}
