using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    Animator catAnimator;
    private int jumpTimer = 0;

    [SerializeField] public float movementSpeed = 2.0f;
    [SerializeField] public float rotationSpeed = 200.0f;
    [SerializeField] public float jumpSpeed = 3.0f;
    void Update () {

        //float inputSpeed = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);

        catAnimator = GetComponent<Animator>();
        Debug.Log("Moving at speed: " + (Mathf.Abs(Input.GetAxis("Horizontal") * movementSpeed) + Mathf.Abs(Input.GetAxis("Vertical") * movementSpeed)));
        catAnimator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        catAnimator.SetFloat("MoveY", Input.GetAxis("Vertical"));
        catAnimator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")*movementSpeed) + (Mathf.Abs(Input.GetAxis("Vertical")*movementSpeed))));

        //if Fire 1 (jump) is pressed
        if (Input.GetAxis("Jump") > 0.0f)
        {
            catAnimator.SetBool("Jump", true);

            //transform.Rotate(0, jumpSpeed * Time.deltaTime * rotationSpeed, 0);
            transform.Translate(0, jumpSpeed * Time.deltaTime, 0);//Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
        } if (Input.GetAxis("Jump") == 0.0f)
        {
            catAnimator.SetBool("Jump", false);
        }
    }
}