using System;
using UnityEngine;

public class ScoreListener : MonoBehaviour
{
    [SerializeField] private int scoreNeededForLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        if (newScore >= scoreNeededForLevel)
        {
            Debug.Log("Level success!");
        }
    }
}
