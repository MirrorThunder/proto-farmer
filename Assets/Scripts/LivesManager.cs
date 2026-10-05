using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public static LivesManager Instance;

    public int lives = 3;

    public TMP_Text livesText;
    public TMP_Text scoreText;

    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;

    private bool gameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateLivesText();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void LoseLife()
    {
        if (gameOver)
            return;

        lives--;

        if (lives < 0)
        {
            lives = 0;
        }

        UpdateLivesText();

        if (lives == 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Vidas: " + lives;
        }
    }

    private void GameOver()
    {
        gameOver = true;

        Debug.Log("GAME OVER");

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        if (livesText != null)
        {
            livesText.gameObject.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null && ScoreManager.Instance != null)
        {
            finalScoreText.text =
                "Puntaje final: " + ScoreManager.Instance.score +
                "\nRécord: " + ScoreManager.Instance.highScore;
        }
    }
}