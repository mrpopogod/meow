using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowableInteractable : MonoBehaviour
{
    public int myForce = 10;
    public void BlowWithForce(Vector3 force)
    {
        //float horizontal = Input.GetAxis("Horizontal"); //how much the cat should turn local left or right
        //float vertical = Input.GetAxis("Vertical"); //how much "forward" the cat should go
        //Vector3 rotationVector = new Vector3(0, horizontal * rotationSpeed, 0);
        //Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.deltaTime);//new Quaternion(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0f, 1f);
        Rigidbody _rb = this.GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.Log("There's an issue with the Rigidbody on this object...");
            return;
        }

        //Vector3 position = _rb.position;

        //float moveDistance = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        _rb.AddForceAtPosition(force*myForce, _rb.position);
        //_rb.MovePosition((_rb.position) + (_transform.forward * moveDistance));// (1-Input.GetAxis("Horizontal")));//(Input.GetAxis("Horizontal") * speed * Time.deltaTime));
        //_rb.MoveRotation(_rb.rotation * deltaRotation);
    }
}
