using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private int currentLevel;
        
        public void LoadNextLevel()
        {
            currentLevel++;
            SceneManager.LoadScene("Level " + currentLevel);
        }
    }
}