using System.Collections;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float speed = 5f; // Default speed, can be adjusted in Inspector
    public float disappearAfterSeconds = 8f; // Time after which the duck will disappear
    private ScoreBoardManager scoreboardManager; // Reference to the scoreboard manager

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the ScoreboardManager in the scene
        scoreboardManager = FindObjectOfType<ScoreBoardManager>();
        StartCoroutine(DisappearAfterTime(disappearAfterSeconds));
    }

    // Update is called once per frame
    void Update()
    {
        // Move the duck to the right (assuming negative right is the intended direction)
        transform.position += -Vector3.right * speed * Time.deltaTime;
        if(!isActiveAndEnabled)
            Destroy(gameObject);
    }

    IEnumerator DisappearAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Before deactivating or destroying the duck, decrease the ducks left count
        if (scoreboardManager != null)
        {
            scoreboardManager.DuckMissed();
        }

        // Now, either deactivate or destroy the GameObject
        gameObject.SetActive(false); // Use this if you want to possibly reuse the duck
        // Destroy(gameObject); // Use this if you are not planning to reuse the duck
    }
}
