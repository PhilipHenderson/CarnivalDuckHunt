using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    public float launchAngle = 0f; // Angle at which the bullet is fired
    public float initialSpeed = 20f; // Initial speed of the bullet
    public float lifespan = 5f; // Lifespan of the bullet in seconds
    public float radians;
    public float verticalSpeed;
    public float horizontalSpeed;
    public Vector3 initialVelocity;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchProjectile();
        Destroy(gameObject, lifespan);
    }

    private void LaunchProjectile()
    {
        radians = launchAngle * Mathf.Deg2Rad;                // Convert angle to radians
        verticalSpeed = initialSpeed * Mathf.Sin(radians);   // Calculate vertical component of the initial speed
        horizontalSpeed = initialSpeed * Mathf.Cos(radians); // Calculate horizontal component of the initial speed

        initialVelocity = -transform.forward * horizontalSpeed + Vector3.up * verticalSpeed;
        rb.velocity = initialVelocity;                       // Apply initial velocity to the Rigidbody
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet hits a duck
        if (collision.gameObject.CompareTag("Duck"))
        {
            ScoreBoardManager scoreboardManager = FindObjectOfType<ScoreBoardManager>();
            if (scoreboardManager != null)
            {
                scoreboardManager.DuckKilled(); 
            }
            Destroy(collision.gameObject); // Destroy duck
        }

        Destroy(gameObject); // Destroy bullet after collision
    }

}
