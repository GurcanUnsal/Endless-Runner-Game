using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class UI_Events : MonoBehaviour
{
    public GameObject resumeButton;
    public GameObject pauseButton;

    public GameObject[] defaultTiles;

    public void PlayGame()
    {
        GameManager.isGameStarted = true;
        pauseButton.SetActive(true);
        StartCoroutine(DestroyInitialTiles());
    }

    private IEnumerator DestroyInitialTiles()
    {
        yield return new WaitForSeconds(10f);
        for(int i = 0; i < defaultTiles.Length; i++)
        {
            Destroy(defaultTiles[i]);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1.0f;
    }
}
