using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Make sure to include the TextMeshPro namespace

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Singleton pattern

    [Header("UI Panels")]
    public GameObject startMenuPanel; // Assign in the Unity Inspector
    public GameObject gameOverPanel;  // Assign in the Unity Inspector
    public GameObject inGameUIPanel;  // Assign in the Unity Inspector

    [Header("Text Displays")]
    public TextMeshProUGUI scoreText; // Assign in the Unity Inspector
    public TextMeshProUGUI timerText; // Assign in the Unity Inspector
    public TextMeshProUGUI finalScoreText; // Assign in the Unity Inspector

    private float timer = 0f;
    public int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance alive across scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    void Start()
    {
        ShowStartMenu();
    }

    void Update()
    {
        if (!startMenuPanel.activeSelf && !gameOverPanel.activeSelf)
        {
            // Only update the timer and score display during gameplay
            timer += Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
    }

    public void ShowStartMenu()
    {
        startMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        inGameUIPanel.SetActive(false); // Make sure the in-game UI is not visible
        Time.timeScale = 0f; // Pause the game
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        inGameUIPanel.SetActive(true); // Activate in-game UI
        timer = 0; // Reset timer
        score = 0; // Reset score
        UpdateScoreDisplay(score); // Initialize score display
        UpdateTimerDisplay(timer); // Initialize timer display
        Time.timeScale = 1f; // Unpause the game
    }

    public void ShowGameOverMenu()
    {
        gameOverPanel.SetActive(true);
        inGameUIPanel.SetActive(false); // Hide the in-game UI
        finalScoreText.text = "You finished the game in " + timer + "and final score is " +
                              (score / Mathf.FloorToInt(timer / 60));
        Time.timeScale = 0f; // Optionally pause the game
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        StartGame(); // Reinitialize the game UI
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay(score);
    }

    private void UpdateScoreDisplay(int newScore)
    {
        scoreText.text = "Coins: " + newScore.ToString();
    }

    private void UpdateTimerDisplay(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime % 60F);
        int milliseconds = Mathf.FloorToInt((currentTime * 100F) % 100F);
        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
