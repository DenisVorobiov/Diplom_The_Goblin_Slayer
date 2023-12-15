using System;

public interface IWinSystem
{
    event Action OnWin;
}


public class WinSystem : IWinSystem
{
    private const int WinScore = 200;
    public event Action OnWin;

    public WinSystem()
    {
        Context.Instance.ScoreSystem.OnScoreChanged += OnScoreChanged;
    }

    public void OnScoreChanged(int score)
    {
        if (score >= WinScore)
        {
           // Context.Instance.AppSystem.Trigger(AppTrigger.ToLootScreen);
           // Context.Instance.ScoreSystem.ResetScore();
            OnWin?.Invoke();
        }
    }
}   