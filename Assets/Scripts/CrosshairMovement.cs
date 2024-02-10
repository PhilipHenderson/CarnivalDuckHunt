using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    public float speed = 5f; // Speed at which the crosshair moves

    void Update()
    {
        MoveCrosshair();
    }

    private void MoveCrosshair()
    {
        // Get input from WASD or arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement vector based on input and speed
        Vector3 movement = new Vector3(horizontal, -vertical, 0) * speed * Time.deltaTime;

        // Apply the movement to the crosshair's position
        transform.position += movement;
    }
}
