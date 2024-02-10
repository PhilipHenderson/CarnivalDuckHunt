using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class ScoreBoardManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assign in the inspector with your TMP Text for score
    public TextMeshProUGUI ducksLeftText;// Assign in the inspector with your UI Text for ducks left
    public int ducksLeft = 30;

    private int score = 0;

    public int DucksLeft{ get { return ducksLeft; } }
    public int Score{ get { return score; } }

    private void Start()
    {
        // Initialize the scoreboard text
        UpdateScoreText();
        UpdateDucksLeftText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void DuckKilled()
    {
        ducksLeft--;
        UpdateDucksLeftText();

        // Assuming 2 points per duck killed
        IncreaseScore(2);
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateDucksLeftText()
    {
        ducksLeftText.text = ducksLeft.ToString();
    }

    // Add this method to the ScoreboardManager script
    public void DuckMissed()
    {
        ducksLeft--;
        UpdateDucksLeftText();
    }
}
