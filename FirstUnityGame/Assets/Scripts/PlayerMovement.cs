using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody physicsBody;
    public Transform cameraLocation;

    public float movingForce;
    public float jumpingForce;
    bool isJumping = false;

    void FixedUpdate() {
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
            physicsBody.AddForce(forceX * Time.deltaTime, 0, forceZ * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            physicsBody.AddForce(-forceX * Time.deltaTime, 0, -forceZ * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            physicsBody.AddForce(-forceZ * Time.deltaTime, 0, forceX * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            physicsBody.AddForce(forceZ * Time.deltaTime, 0, -forceX * Time.deltaTime);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                physicsBody.AddForce(0, jumpingForce, 0);
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
