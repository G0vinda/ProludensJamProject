using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GlobalScoreCounter : MonoBehaviour
    {
        [SerializeField] private List<int> levelScoreThresholds;
        [SerializeField] private int currentLevel;
        [SerializeField] private int score;
        
        [SerializeField] private GlobalScoreText scoreText;
        
        public void TryGoToNextLevel()
        {
            if (score >= levelScoreThresholds[currentLevel])
                GoToNextLevel();
            else
            {
                Debug.LogWarning("Score is too low to proceed to next Level");
            }
        }

        private void GoToNextLevel()
        {
            currentLevel++;
            score = 0;
            scoreText.SetScoreText(score);
            SceneManager.LoadScene(currentLevel);
        }
    }
}