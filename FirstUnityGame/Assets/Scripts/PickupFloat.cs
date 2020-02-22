using UnityEngine;

public class PickupFloat : MonoBehaviour
{
    public float amplitude; // Best between .001 - .01
    public float speed;     // Best between 1 - 5

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + amplitude * Mathf.Sin(speed * Time.time), transform.position.z);
    }
}
