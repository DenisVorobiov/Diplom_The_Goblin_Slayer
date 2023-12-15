using System;

public interface IScoreSystem
{
    int Score { get; }
    void AddScore(int score);
    void ResetScore();
    event Action<int> OnScoreChanged;
}