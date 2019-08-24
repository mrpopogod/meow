using UnityEngine;

public class PuzzleTarget : MonoBehaviour
{
    public GameObject piece = null;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered the " + this.name);

        if (other.gameObject == piece)
        {

            other.transform.position = this.transform.position;
            //other.attachedRigidbody.mass = 1000; //TODO: there's probably a better way to lock the piece
			other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;

            Cat theCat = FindObjectOfType<Cat>();

            if (theCat != null)
            {
                Debug.Log("Hey, we solved a puzzle, let's find the cat and let them know we did a good.");
                Debug.Log(theCat.name);


            }

        }
    }
}
