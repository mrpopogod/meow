using UnityEngine;

public class PuzzleTarget : MonoBehaviour
{
    public GameObject piece = null;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered the " + this.name);

        if (other.gameObject == piece)
        {
            var pos = other.transform.position;
            pos.x = this.transform.position.x;
            pos.z = this.transform.position.z;
            other.transform.position = pos;
            //other.attachedRigidbody.mass = 1000; //TODO: there's probably a better way to lock the piece
			other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
            this.transform.parent.gameObject.SetActive(false);
            Cat theCat = FindObjectOfType<Cat>();
            

            if (theCat != null)
            {
                Debug.Log("Hey, we solved a puzzle, let's find the cat and let them know we did a good.");
                Debug.Log(theCat.name);


            }

        }
    }
}
