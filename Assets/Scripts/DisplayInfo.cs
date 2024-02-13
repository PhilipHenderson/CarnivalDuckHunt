using UnityEngine;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    public TextMeshProUGUI initialVelocityText;
    public TextMeshProUGUI launchAngleText;
    public Transform gunTransform;
    public TextMeshProUGUI radiansText;
    public TextMeshProUGUI currentVelocityText;
    public TextMeshProUGUI additionalItem1Text;
    public TextMeshProUGUI additionalItem2Text;

    private BulletPhysics bulletScript;

    private void Update()
    {
        BulletPhysics bulletScript = FindObjectOfType<BulletPhysics>();
        if (bulletScript)
        {
            initialVelocityText.text = $"Launch Vector: {bulletScript.initialVelocity:F2}";

            if (gunTransform)
            {
                Vector3 forwardFlat = new Vector3(gunTransform.forward.x, 0f, gunTransform.forward.z);
                float xAngle = Vector3.SignedAngle(Vector3.forward, forwardFlat.normalized, Vector3.up);
                float yAngle = Vector3.SignedAngle(forwardFlat.normalized, gunTransform.forward, Vector3.Cross(Vector3.up, forwardFlat.normalized));

                launchAngleText.text = $"X Launch Angle: {xAngle:F2}\n" +
                                       $"Y Launch Angle: {yAngle:F2}";

                float radians = yAngle * Mathf.Deg2Rad;
                radiansText.text = $"Radians: {radians:F2}";
            }

            currentVelocityText.text = $"Current Velocity: {bulletScript.rb.velocity.magnitude:F2}";
        }
        else
        {
            if (gunTransform)
            {
                Vector3 forwardFlat = new Vector3(gunTransform.forward.x, 0f, gunTransform.forward.z);
                float xAngle = Vector3.SignedAngle(Vector3.forward, forwardFlat.normalized, Vector3.up);
                float yAngle = Vector3.SignedAngle(forwardFlat.normalized, gunTransform.forward, Vector3.Cross(Vector3.up, forwardFlat.normalized));

                launchAngleText.text = $"X Launch Angle: {xAngle:F2}\n" +
                                       $"Y Launch Angle: {yAngle:F2}";

                float radians = yAngle * Mathf.Deg2Rad;
                radiansText.text = $"Radians: {radians:F2}";
            }
        }
    }
}
