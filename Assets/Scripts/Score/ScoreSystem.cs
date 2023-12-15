using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : IScoreSystem
{
    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;

    public void AddScore(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke(Score);
    }
    public void ResetScore()
    {
        Score = 0;
    }

}

