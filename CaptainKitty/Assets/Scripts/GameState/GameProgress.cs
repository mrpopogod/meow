public class GameProgress
{
    private IState currentState;
    private IState previousState;

    private GameProgress _instance;

    public GameProgress Progress
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameProgress();
            }
            return _instance;
        }
    }

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

    private GameProgress () { }
}
