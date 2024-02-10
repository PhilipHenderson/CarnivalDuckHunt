using UnityEngine;

public class GunAim : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed at which the gun rotates
    public GameObject bulletPrefab; // The bullet prefab to spawn

    public Transform bulletSpawnPoint; // The point from where bullets will be fired

    void Update()
    {
        AimGunWithKeyboard();

        // Check if the space bar was pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    private void AimGunWithKeyboard()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A and D keys
        float verticalInput = Input.GetAxis("Vertical"); // W and S keys

        // Calculate the rotation amount. If you want to invert controls, multiply by -1.
        float rotationAmountX = horizontalInput * -rotationSpeed * Time.deltaTime;
        float rotationAmountY = verticalInput * -rotationSpeed * Time.deltaTime;

        // Rotate the gun around the y-axis for horizontal input (A and D keys)
        transform.Rotate(0, rotationAmountX, 0, Space.World);

        // Rotate the gun around the x-axis for vertical input (W and S keys)
        transform.Rotate(rotationAmountY, 0, 0, Space.Self);
    }

    private void FireBullet()
    {
        // Instantiate the bullet at the position and rotation of the gun
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation); // Use the gun's rotation
        }
        else
        {
            Debug.LogError("Bullet prefab or spawn point not set!");
        }
    }

}
