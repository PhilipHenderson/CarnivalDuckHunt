using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;
using TMPro;

public class LevelChanger : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;
    public GameObject winCanvas; // This will be searched for at startup
    public GameObject loseCanvas; // This will be searched for at startup
    public TextMeshProUGUI winScoreText; // This will be searched for at startup
    public TextMeshProUGUI loseScoreText; // This will be searched for at startup

    private int playerScore = 0;

    private void Start()
    {
        // Attempt to find the canvases and text components if not assigned
        winCanvas = GameObject.Find("GameOverCanvas");
        loseCanvas = GameObject.Find("LoseCanvas");

        // For TextMeshProUGUI, it's a bit more complex as they're components of GameObjects
        // You could name your TextMeshPro objects specifically to find them, like "WinScoreText" and "LoseScoreText"
        winScoreText = GameObject.Find("GameOverScore")?.GetComponent<TextMeshProUGUI>();
        loseScoreText = GameObject.Find("LoseScoreText")?.GetComponent<TextMeshProUGUI>();

        // Deactivate win and lose canvases at start if they exist
        if (winCanvas) winCanvas.SetActive(false);
        if (loseCanvas) loseCanvas.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        EditorApplication.isPlaying = false; // This will only work in the editor
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

    // Call this method when the player wins
    public void ShowWinScreen()
    {
        if (winCanvas && winScoreText)
        {
            winCanvas.SetActive(true);
            winScoreText.text = "Score: " + playerScore.ToString();
        }
    }

    public void ShowLoseScreen()
    {
        if (loseCanvas && loseScoreText)
        {
            loseCanvas.SetActive(true);
            loseScoreText.text = "Score: " + playerScore.ToString();
        }
    }
}
