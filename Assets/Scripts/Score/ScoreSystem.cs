using System;
using UnityEngine;

public class ScoreSystem : IScoreSystem
{
    public int Score { get; private set; }
    public int Lvl { get; private set; }

    private int scoreToNextLvl = 200;

    public event Action<int> OnScoreChanged;
    public event Action<int> OnlvlUP;

    public void AddScore(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke(Score);
        if (Score >= scoreToNextLvl)
        {
            LvlUP();
        }
    }

    private void LvlUP()
    {
        Lvl++;
        OnlvlUP?.Invoke(Lvl);
        ResetScore();
        scoreToNextLvl = ExperienceForNextLevel();
    }

    public void ResetScore()
    {
        Score = 0;
    }

    private int ExperienceForNextLevel()
    {
        return Mathf.RoundToInt(scoreToNextLvl * 1.2f);
    }
}