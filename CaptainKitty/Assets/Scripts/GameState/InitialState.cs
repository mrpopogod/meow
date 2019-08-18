using UnityEngine;

public class InitialState : IState
{
  public void Enter()
  {
    Debug.Log("Entering Initial State");
  }

  public void Execute()
  {
    
  }

  public void Exit()
  {
    Debug.Log("Exiting Initial State");
  }
}
