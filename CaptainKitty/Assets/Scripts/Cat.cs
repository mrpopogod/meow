using UnityEngine;

public class Cat : MonoBehaviour
{
    private CatMovement movement;
    public GameObject firePrefab;

    // Use this for initialization
    void Start()
    {
        movement = new CatMovement(GetComponent<Rigidbody>(), GetComponent<Animator>(), GetComponent<Transform>(), firePrefab);
        GameProgress.Progress.ChangeState(new InitialState());
    }

    void Update()
    {
        movement.Update();
        GameProgress.Progress.RunCurrentState();
    }
}
