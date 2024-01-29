using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    private bool isPaused = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        SceneManager.sceneLoaded += OnSceneLoaded;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResumeGame();
    }

    public void TogglePauseButton()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pausePanel.SetActive(true);
        isPaused = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayerWin()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        gameWinPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        isPaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}