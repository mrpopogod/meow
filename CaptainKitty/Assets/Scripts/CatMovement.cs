using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    Animator catAnimator; 
    [SerializeField] public float movementSpeed = 5.0f;
    [SerializeField] public float rotationSpeed = 200.0f;
    void Update () {

        //float inputSpeed = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);

        catAnimator = GetComponent<Animator>();
        Debug.Log("Moving at speed: " + (Mathf.Abs(Input.GetAxis("Horizontal") * movementSpeed) + Mathf.Abs(Input.GetAxis("Vertical") * movementSpeed)));
        catAnimator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        catAnimator.SetFloat("MoveY", Input.GetAxis("Vertical"));
        catAnimator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")*movementSpeed) + (Mathf.Abs(Input.GetAxis("Vertical")*movementSpeed))));
    }
}