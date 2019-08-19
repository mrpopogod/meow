using UnityEngine;

public class Cat : MonoBehaviour
{
    private CatMovement movement;
    private GameProgress progress = new GameProgress();
    public GameObject firePrefab;

  // Use this for initialization
    void Start()
    {
        movement = new CatMovement(GetComponent<Rigidbody>(), GetComponent<Animator>(), GetComponent<Transform>(), firePrefab);
        progress.ChangeState(new InitialState());
    }

  // Update is called once per frame
    void Update()
    {
        movement.Update();
        progress.RunCurrentState();
    }
}
