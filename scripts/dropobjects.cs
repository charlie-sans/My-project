using UnityEngine;
using UnityEngine.XR;

public class dropobjects : MonoBehaviour
{
    public float targetY = 0f;  // The desired Y position

    private float speed = 2f;  // The speed at which the object moves

    public void movething()
    {
        // Move the object downwards
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the object has reached the target Y position
        if (transform.position.y <= targetY)
        {
            // Stop the object from moving
            enabled = false;
        }
    }
}
