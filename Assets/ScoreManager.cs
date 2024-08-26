using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public Text scoreText;  // Reference to the UI Text element for displaying the score

    private int score = 0;  // Player's score

    void Awake()
    {
        // Ensure that there's only one instance of ScoreManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increment the score
    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
