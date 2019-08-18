using UnityEngine;

public class Cat : MonoBehaviour
{
  [SerializeField] CatMovement movement;

  // Use this for initialization
  void Start()
  {
    movement = gameObject.AddComponent<CatMovement>();
  }

  // Update is called once per frame
  void Update()
  {
    movement.Update();
  }
}
