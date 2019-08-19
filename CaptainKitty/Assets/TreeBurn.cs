using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBurn : MonoBehaviour
{
    [SerializeField] private GameObject stump;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private int numFramesRequired;
    private List<ParticleCollisionEvent> collisionEvents;
    private int flamesReceived = 0;

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    public void OnParticleCollision(GameObject other)
    {
        var ps = other.GetComponent<ParticleSystem>();
        ParticlePhysicsExtensions.GetCollisionEvents(ps, gameObject, collisionEvents);
        for (int i = 0; i < collisionEvents.Count; i++)
        {
            flamesReceived++;
            if (flamesReceived > numFramesRequired)
            {
                Burn();
                break;
            }
        }
    }

    public void Burn()
    {
        var newPosition = gameObject.transform.position;
        newPosition.y -= 1.7f;
        var fire = Instantiate(firePrefab, newPosition, gameObject.transform.rotation);
        Destroy(fire, 2.0f);
        Instantiate(stump, newPosition, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
