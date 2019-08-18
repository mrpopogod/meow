public class GameProgress
{
  private IState currentState;
  private IState previousState;

  public void ChangeState (IState newState)
  {
    if(currentState != null)
    {
      currentState.Exit();
    }
    previousState = currentState;
    currentState = newState;
    newState.Enter();
  }
  
  public void RunCurrentState ()
  {
    var runningState = currentState;
    if (runningState != null) runningState.Execute();
  }
}
