using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    public float launchAngle = 0f; // Angle at which the bullet is fired
    public float initialSpeed = 20f; // Initial speed of the bullet
    public float lifespan = 5f; // Lifespan of the bullet in seconds

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchProjectile();
        Destroy(gameObject, lifespan);
    }

    private void LaunchProjectile()
    {
        float radians = launchAngle * Mathf.Deg2Rad; // Convert angle to radians
        float verticalSpeed = initialSpeed * Mathf.Sin(radians); // Calculate vertical component of the initial speed
        float horizontalSpeed = initialSpeed * Mathf.Cos(radians); // Calculate horizontal component of the initial speed

        Vector3 initialVelocity = -transform.forward * horizontalSpeed + Vector3.up * verticalSpeed;
        rb.velocity = initialVelocity; // Apply initial velocity to the Rigidbody
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet hits a duck
        if (collision.gameObject.CompareTag("Duck"))
        {
            ScoreBoardManager scoreboardManager = FindObjectOfType<ScoreBoardManager>();
            if (scoreboardManager != null)
            {
                scoreboardManager.IncreaseScore(2); // Assuming 2 points per duck hit
            }
            Destroy(collision.gameObject); // Destroy the duck
        }

        Destroy(gameObject); // Destroy the bullet after collision
    }
}
