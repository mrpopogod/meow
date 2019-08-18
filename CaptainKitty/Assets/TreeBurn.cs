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

    public void Burn()
    {
        // TODO: a particle
        var stump = Instantiate(_stump, gameObject.transform);
        stump.transform.localScale = new Vector3(50f, 50f, 50f);
        Destroy(gameObject);
    }
}
