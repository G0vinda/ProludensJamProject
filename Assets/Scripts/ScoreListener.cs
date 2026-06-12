using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ScoreListener : MonoBehaviour
{
    [SerializeField] private int scoreNeededForLevel;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private GlobalScoreText scoreText;
    [SerializeField] private LevelSuccessText levelSuccessText;
    
    void Start()
    {
        Score.Reset();
    }

    private void OnEnable()
    {
        Score.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        Score.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        Debug.Log("Score: " + newScore);
        
        scoreText.SetScoreText(newScore);
        
        if (newScore >= scoreNeededForLevel)
        {
            Debug.Log("Level success!");
            nextLevelButton.interactable = true;
            nextLevelButton.image.color = new Color32(0xFF, 0xC7, 0x00, 0xFF);
            levelSuccessText.Show();
        }
    }

    [ContextMenu("Increase Score Test")]
    private void IncreaseScore()
    {
        Score.Increase(1000);
    }
}
