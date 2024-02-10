using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeDuration = 2f;

    private Rigidbody rb; // Reference to the Rigidbody component

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeDuration); // Destroy the bullet after a certain time to prevent clutter
    }

    private void FixedUpdate()
    {
        // Move the bullet in its local forward direction using Rigidbody for physics interaction
        rb.MovePosition(rb.position + -transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet hit a duck
        if (collision.gameObject.CompareTag("Duck")) // Make sure your duck objects have the tag "Duck"
        {
            Destroy(collision.gameObject); // Destroy the duck
        }

        Destroy(gameObject); // Destroy the bullet after collision with anything
    }
}
