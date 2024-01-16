using System;
using System.Collections;
using UnityEngine;

public class InitXP : MonoBehaviour
{
    private int _scoreSystem;
    private void Start()
    {
        _scoreSystem = Context.Instance.ScoreSystem.ScoreToNextLvl;

        _scoreSystem = 200;
    }
}