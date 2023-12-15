using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreView : MonoBehaviour
{
    [SerializeField] private LocalizedTextView _localizedText;

    void Start()
    {
        Context.Instance.ScoreSystem.OnScoreChanged += OnScore;
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
