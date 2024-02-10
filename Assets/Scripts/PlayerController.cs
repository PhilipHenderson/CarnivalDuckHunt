using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed at which the gun rotates
    public GameObject bulletPrefab; // The bullet prefab to spawn
    public Transform bulletSpawnPoint; // The point from where bullets will be fired
    public GameObject pauseMenuCanvas; // Assign the Pause Menu Canvas in the Inspector

    private bool isPaused = false; // Tracks the pause state of the game

    void Update()
    {
        AimGunWithKeyboard();

        // Check if the space bar was pressed
        if (Input.GetKeyDown(KeyCode.Space) && !isPaused)
        {
            FireBullet();
        }

        // Toggle pause state when R is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePause();
        }
    }

    private void AimGunWithKeyboard()
    {
        if (!isPaused)
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // A and D keys
            float verticalInput = Input.GetAxis("Vertical"); // W and S keys

            // Calculate the rotation amount
            float rotationAmountX = horizontalInput * -rotationSpeed * Time.deltaTime;
            float rotationAmountY = verticalInput * -rotationSpeed * Time.deltaTime;

            // Rotate the gun around the y-axis for horizontal input
            transform.Rotate(0, rotationAmountX, 0, Space.World);

            // Rotate the gun around the x-axis for vertical input
            transform.Rotate(rotationAmountY, 0, 0, Space.Self);
        }
    }

    private void FireBullet()
    {
        // Instantiate the bullet at the position and rotation of the gun
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Bullet prefab or spawn point not set!");
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenuCanvas.SetActive(isPaused); // Activate the pause menu canvas when paused

        // Optionally, handle other game state changes or UI updates here
    }
}
