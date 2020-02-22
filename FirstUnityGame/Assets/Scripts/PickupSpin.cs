using UnityEngine;

public class PickupSpin : MonoBehaviour
{
    public float speed; // Best speed around 50

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * speed);
    }
}
