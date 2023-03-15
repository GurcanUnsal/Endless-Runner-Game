using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted;
    public static bool gameOver;

    public GameObject gameOverPanel;
    public GameObject pauseButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Button playButton;
    
    private void Start()
    {
        gameOverPanel.SetActive(false);
        isGameStarted = false;
        gameOver = false;
    }

    private void Update()
    {
        if(isGameStarted)
        {
            playButton.gameObject.SetActive(false);
            
        }

        if(gameOver)
        {
            gameOverPanel.SetActive(true);
            pauseButton.SetActive(false);

            AudioSource mainTheme = FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[3];
            mainTheme.Stop();
            
            if(PlayerController.gold > PlayerPrefs.GetInt("HighScore"))
            {
                SaveHighScore();
            }
            LoadHighScore();
            scoreText.text = "Score : " + PlayerController.gold.ToString();
        }
    }

    private void LoadHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score : " + highScore.ToString();
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", PlayerController.gold);
    }


}
