using System.Collections;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float speed = 5f; // Default speed, can be adjusted in Inspector
    public float disappearAfterSeconds = 5f; // Time after which the duck will disappear

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisappearAfterTime(disappearAfterSeconds));
    }

    // Update is called once per frame
    void Update()
    {
        // Move the duck to the right
        transform.position += -Vector3.right * speed * Time.deltaTime;
    }

    IEnumerator DisappearAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Option 1: Deactivate the GameObject (it can be reactivated later)
        gameObject.SetActive(false);

        // Option 2: Destroy the GameObject entirely (uncomment the line below if you prefer this)
        // Destroy(gameObject);
    }
}
