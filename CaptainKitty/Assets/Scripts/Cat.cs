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
<<<<<<< HEAD
    
  // Update is called once per frame
=======

    // Update is called once per frame
>>>>>>> ad9b6fd5c4e428f766076cdfcff4b6cfed018377
    void Update()
    {
        movement.Update();
        game.Progress.RunCurrentState();
    }
}
