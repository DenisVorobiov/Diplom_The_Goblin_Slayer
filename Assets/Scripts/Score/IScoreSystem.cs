using System;

public interface IScoreSystem
{
    int Score { get; }
    int ScoreToNextLvl { get; }
    void AddScore(int score);
   

    void ResetScore();
    event Action<int> OnScoreChanged;
    event Action<int> OnlvlUP;
    event Action<int> OnExperienceProgres;
}