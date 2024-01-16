using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nextLevelScoreText;
    [SerializeField] private LocalizedTextView _localizedTextLvl;
    [SerializeField] private LocalizedTextView _localizedTextXp;
    [SerializeField] private Image _progressBar;

    void Start()
    {
        Context.Instance.ScoreSystem.OnlvlUP += OnLvling;
        Context.Instance.ScoreSystem.OnScoreChanged += OnScore;
        Context.Instance.ScoreSystem.OnExperienceProgres += OnExperienceProgres;
    }
    private void OnExperienceProgres(int exp)
    {
        int currentExp = Context.Instance.ScoreSystem.Score;              
        int expToNextLevel = Context.Instance.ScoreSystem.ScoreToNextLvl;

        if (currentExp >= expToNextLevel)
        {
            int remainingExp = currentExp - expToNextLevel;
            SetFill(0f);
            AddExperienceToProgressBar(remainingExp);
            
            UpdateText();
        }
        else
        {
            float fillAmount = (float)currentExp / expToNextLevel;
            SetFill(fillAmount);
        }
    }
    
    private void AddExperienceToProgressBar(int exp)
    {
        float currentFill = _progressBar.fillAmount;
        float remainingFill = 1f - currentFill;
        float addedFill = (float)exp / Context.Instance.ScoreSystem.ScoreToNextLvl;
        
        float newFillAmount = Mathf.Min(currentFill + addedFill, 1f);
        
        SetFill(newFillAmount);
    }
    private void SetFill(float fillAmount)
    {
       
        _progressBar.fillAmount = fillAmount;
    }
    
    private void UpdateText()
    {
        // Оновлення тексту для кількості очок і кількості очок до наступного рівня
        _nextLevelScoreText.text = $"{Context.Instance.ScoreSystem.ScoreToNextLvl}";
    }

    private void OnLvling(int lvl)
    {
        _localizedTextXp.SetParameters(new object []{lvl});
    }
    private void OnScore(int score)
    {
        _localizedTextLvl.SetParameters(new object[] {score});
    }
    private void OnDestroy()
    {
        Context.Instance.ScoreSystem.OnlvlUP -= OnLvling;
        Context.Instance.ScoreSystem.OnScoreChanged -= OnScore;
        Context.Instance.ScoreSystem.OnExperienceProgres -= OnExperienceProgres;
    }
}
