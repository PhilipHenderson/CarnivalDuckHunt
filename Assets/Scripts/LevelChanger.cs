using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;
using TMPro;

public class LevelChanger : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;
    public GameObject gameoverCanvas;
    public GameObject pauseCanvas;
    public TextMeshProUGUI gameoverScoreText;
    ScoreBoardManager scoreboardManager;

    private void Start()
    {
        scoreboardManager = FindObjectOfType<ScoreBoardManager>();

        gameoverCanvas = GameObject.Find("GameOverCanvas");
        pauseCanvas = GameObject.Find("PauseUI");
        gameoverScoreText = GameObject.Find("GameOverScore")?.GetComponent<TextMeshProUGUI>();

        if (gameoverCanvas) gameoverCanvas.SetActive(false);
        if (pauseCanvas) pauseCanvas.SetActive(false);
    }

    private void Update()
    {
        if (scoreboardManager != null && scoreboardManager.DucksLeft == 0)
        {
            if (gameoverCanvas && gameoverScoreText)
            {
                gameoverCanvas.SetActive(true);
                gameoverScoreText.text = scoreboardManager.Score.ToString();
            }
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
        Debug.Log("Quit game requested.");
    }

    public void ShowMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    public void ShowCredits()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
}
