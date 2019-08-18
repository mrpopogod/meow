using UnityEngine;

public class Cat : MonoBehaviour
{
  [SerializeField] CatMovement movement;
  private GameProgress progress = new GameProgress();

  // Use this for initialization
  void Start()
  {
    movement = gameObject.AddComponent<CatMovement>();
    progress.ChangeState(new InitialState());
  }

  // Update is called once per frame
  void Update()
  {
    movement.Update();
    progress.RunCurrentState();
  }
}
