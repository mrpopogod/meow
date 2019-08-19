using System;

public sealed class GameProgress
{
    private IState currentState;
    private IState previousState;

    private static readonly Lazy<GameProgress> _instance = new Lazy<GameProgress>(() => new GameProgress());

    public static GameProgress Progress { get { return _instance.Value; } }

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
