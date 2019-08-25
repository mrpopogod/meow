using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public AudioSource treasureSound;
    public bool isLocked = true;
    // Start is called before the first frame update
    void Start()
    {
        treasureSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider other)
    {
        Cat theCat = FindObjectOfType<Cat>();
        if (other.gameObject == theCat.gameObject)
        {
            //Debug.Log(theCat.name + " is the cat, but instead it was a " + other.name);
            if ((theCat != null) && (isLocked))
            {
                Debug.Log("Hey, we solved a puzzle, let's find the cat and let them know we did a good.");
                Debug.Log(theCat.name);
                
                
                //TODO: Check if this chest can be unlocked right now
                /*
                 if (theCat.progress == this.prereq){
                 }
                 */
                theCat.LevelUp();
                treasureSound.Play();
                isLocked = false;
            }

        }
    }
}
