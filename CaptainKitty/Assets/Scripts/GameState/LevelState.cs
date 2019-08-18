using UnityEngine;
using System.Collections;

public enum Level
{
  Water,
  Fire,
  Earth,
  Wind
}

public class LevelState : IState
{
  private Level currentLevel;

  public LevelState(Level newLevel)
  {
    currentLevel = newLevel;
  }
  
  public void Enter()
  {
    Debug.Log($"Entering Level State at Level {currentLevel}");
  }

  public void Execute()
  {
    
  }

  public void Exit()
  {
    Debug.Log("Entering Initial State");
  }
}
