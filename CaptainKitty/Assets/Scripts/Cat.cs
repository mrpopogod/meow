using UnityEngine;

public class Cat : MonoBehaviour
{
    private CatMovement movement;
    private GameProgress game;
    public GameObject firePrefab;

    // Use this for initialization
    void Start()
    {
        movement = new CatMovement(GetComponent<Rigidbody>(), GetComponent<Animator>(), GetComponent<Transform>(), firePrefab);
        game.Progress.ChangeState(new InitialState());
    }

    // Update is called once per frame
    void Update()
    {
        movement.Update();
        game.Progress.RunCurrentState();
    }
}
