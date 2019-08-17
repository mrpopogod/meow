using UnityEngine;

public class CatMovement : MonoBehaviour
{
    Animator catAnimator; 
    [SerializeField] public float movementSpeed = 5.0f;
    [SerializeField] public float sprintSpeed = 10.0f;
    [SerializeField] public float rotationSpeed = 200.0f;
    void Update () {
        var speed = movementSpeed;
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
          speed = sprintSpeed;
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        catAnimator = GetComponent<Animator>();
        Debug.Log("Moving at speed: " + (Mathf.Abs(Input.GetAxis("Horizontal") * speed) + Mathf.Abs(Input.GetAxis("Vertical") * speed)));
        catAnimator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        catAnimator.SetFloat("MoveY", Input.GetAxis("Vertical"));
        catAnimator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")* speed) + (Mathf.Abs(Input.GetAxis("Vertical")* speed))));
    }
}