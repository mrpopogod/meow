using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBurn : MonoBehaviour
{
    [SerializeField] private GameObject _stump;

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Burn();
        }
    }

    // TODO: This should be triggered; can be a received event or an OnTriggerEntered with our fire power
    public void Burn()
    {
        // TODO: a particle
        var newPosition = gameObject.transform.position;
        newPosition.y -= 1.7f;
        Instantiate(_stump, newPosition, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
