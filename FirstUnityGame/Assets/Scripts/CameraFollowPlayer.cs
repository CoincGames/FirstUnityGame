using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerLocation;
    public Vector3 cameraOffset;
    public float degreesToRotate;

    // Update is called once per frame
    void Update()
    {
        // Updates the camera to follow the player
        transform.position = playerLocation.position + cameraOffset;

        // Rotates the camera clockwise
        if (Input.GetKey("q"))
        {
            cameraOffset = transform.position - playerLocation.position;
            cameraOffset = Quaternion.Euler(0, degreesToRotate, 0) * cameraOffset;
            transform.position = cameraOffset + playerLocation.position;
            transform.LookAt(playerLocation.position + new Vector3(0, 1, 0));
        }

        // Rotates the camera counter-clockwise
        if (Input.GetKey("e"))
        {
            cameraOffset = transform.position - playerLocation.position;
            cameraOffset = Quaternion.Euler(0, -degreesToRotate, 0) * cameraOffset;
            transform.position = cameraOffset + playerLocation.position;
            transform.LookAt(playerLocation.position + new Vector3(0, 1, 0));
        }
    }
}
