using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The player that is being followed.")]
    private Rigidbody playerBody;
    [SerializeField]
    [Tooltip("The Camera to move around which follows the player.")]
    private Transform cameraLocation;
    [SerializeField]
    [Tooltip("The respawn point of the player when reset.")]
    private Transform respawnPoint;


    [Header("Properties")]
    [SerializeField]
    [Tooltip("The force applied in any of the moving directions.")]
    private float movingForce;
    [SerializeField]
    [Tooltip("The force applied which acts like a jump.")]
    private float jumpingForce;
    bool isJumping = false;

    void FixedUpdate()
    {
        UpdateMovement();

        if (transform.position.y < -10)
        {
            transform.position = respawnPoint.position;
            playerBody.velocity = new Vector3(0, 0, 0);
            playerBody.angularVelocity = new Vector3(0, 0, 0);
        }
    }

    private void UpdateMovement()
    {
        // Movement
        // http://zonalandeducation.com/mstm/physics/mechanics/forces/forceComponents/forceComponents.html
        float z = transform.position.z - cameraLocation.position.z;
        float x = transform.position.x - cameraLocation.position.x;
        float radianAngle = Mathf.Atan(z / x);
        float forceX = movingForce * Mathf.Cos(radianAngle);
        float forceZ = movingForce * Mathf.Sin(radianAngle);

        // Fixes the sign invalidity on certain movement vectors
        if ((x < 0 && z < 0) || (x < 0 && z > 0))
        {
            forceX *= -1;
            forceZ *= -1;
        }

        if (Input.GetKey("w"))
        {
            playerBody.AddForce(forceX * Time.deltaTime, 0, forceZ * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            playerBody.AddForce(-forceX * Time.deltaTime, 0, -forceZ * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            playerBody.AddForce(-forceZ * Time.deltaTime, 0, forceX * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            playerBody.AddForce(forceZ * Time.deltaTime, 0, -forceX * Time.deltaTime);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                playerBody.AddForce(0, jumpingForce, 0);
                isJumping = true;
            }
        }
    }

    void OnCollisionEnter()
    {
        if (isJumping)
            isJumping = false;
    }
}
