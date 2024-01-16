using System;
using UnityEngine;

public class ScoreSystem : IScoreSystem
{
    public int Score { get; private set; }
    public int Lvl  { get; private set; }
    public int ScoreToNextLvl { get; set; }

    public event Action<int> OnScoreChanged;
    public event Action<int> OnlvlUP;
    public event Action<int> OnExperienceProgres;
    
    //private int remainingExpToNextLevel;
    
    public ScoreSystem(int initialScoreToNextLvl, int startLvl)
    {
        ScoreToNextLvl = initialScoreToNextLvl;
        Lvl = startLvl;
        // remainingExpToNextLevel = 0;
    }
    [ContextMenu("AddScore")]
    public void AddScore(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke(Score);
        OnExperienceProgres?.Invoke(Score);
        if (Score >= ScoreToNextLvl)
            LvlUP();
    }

    private void LvlUP()
    {
        Lvl++;
        OnlvlUP?.Invoke(Lvl);
        ResetScore();
        ScoreToNextLvl = ExperienceForNextLevel();
    }
    
    public void ResetScore()
    {
        Score = 0;
    }

    private int ExperienceForNextLevel()
    {
        return Mathf.RoundToInt(ScoreToNextLvl * 1.25f);
    }
}