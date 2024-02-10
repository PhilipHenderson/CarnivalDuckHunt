using System.Collections;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    public GameObject duckPrefab;
    public Transform[] rowStartPos;

    public int minDuckySpawnTime = 1; // Minimum spawn time in seconds
    public int maxDuckySpawnTime = 5; // Maximum spawn time in seconds

    public bool gameRunning;

    private void Start()
    {
        gameRunning = true;
        StartCoroutine(SpawnDucks()); // Start the spawning process
    }

    IEnumerator SpawnDucks()
    {
        while (gameRunning) // Infinite loop to keep spawning ducks
        {
            int randomRowStart = Random.Range(0, rowStartPos.Length); // Adjusted range to match array indexing
            Instantiate(duckPrefab, rowStartPos[randomRowStart].position, Quaternion.identity); // Corrected instantiation to use position and default rotation

            int randomSeconds = Random.Range(minDuckySpawnTime, maxDuckySpawnTime + 1); // Ensure maxDuckySpawnTime is inclusive
            yield return new WaitForSeconds(randomSeconds); // Wait for a random duration before spawning the next duck
        }
    }
}
