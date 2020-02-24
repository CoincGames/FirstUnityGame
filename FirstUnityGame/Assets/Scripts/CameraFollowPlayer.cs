using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The player object to follow with the camera.")]
    private Transform playerLocation;
    [SerializeField]
    [Tooltip("The camera distance offset from the player.")]
    private Vector3 cameraOffset;
    [SerializeField]
    [Tooltip("The rate of rotation on the camera around the player.")]
    [Range(.5f, 5f)]
    private float degreesToRotatePerFrame;

    private void Start()
    {
        transform.LookAt(playerLocation.position + new Vector3(0, .5f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the camera to follow the player
        transform.position = playerLocation.position + cameraOffset;


        // Rotates the camera clockwise
        if (Input.GetKey("q"))
        {
            cameraOffset = transform.position - playerLocation.position;
            cameraOffset = Quaternion.Euler(0, -degreesToRotatePerFrame, 0) * cameraOffset;
            transform.position = cameraOffset + playerLocation.position;
            transform.LookAt(playerLocation.position + new Vector3(0, .25f, 0));
        }

        // Rotates the camera counter-clockwise
        if (Input.GetKey("e"))
        {
            cameraOffset = transform.position - playerLocation.position;
            cameraOffset = Quaternion.Euler(0, degreesToRotatePerFrame, 0) * cameraOffset;
            transform.position = cameraOffset + playerLocation.position;
            transform.LookAt(playerLocation.position + new Vector3(0, .25f, 0));
        }
    }
}
