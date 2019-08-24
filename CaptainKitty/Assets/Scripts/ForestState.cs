using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestState : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Entered the forest");
            other.GetComponent<Cat>().EnteredForest();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Left the forest");
            other.GetComponent<Cat>().LeftForest();
        }
    }
}
