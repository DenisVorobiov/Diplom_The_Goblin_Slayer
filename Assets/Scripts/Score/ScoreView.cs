using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreView : MonoBehaviour
{
    [SerializeField] private LocalizedTextView _localizedText;
    [SerializeField] private LocalizedTextView _localizedText2;

    void Start()
    {
        Context.Instance.ScoreSystem.OnlvlUP += OnLvling;
        Context.Instance.ScoreSystem.OnScoreChanged += OnScore;
    }

    private void OnLvling(int lvl)
    {
        _localizedText2.SetParameters(new object []{lvl});
    }
    private void OnScore(int score)
    {
        _localizedText.SetParameters(new object[] {score});
    }
    private void OnDestroy()
    {
        Context.Instance.ScoreSystem.OnScoreChanged -= OnScore;
    }
}
