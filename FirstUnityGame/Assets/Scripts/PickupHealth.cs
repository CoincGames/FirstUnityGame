using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public GameObject owner;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.addScore(50);
        Destroy(owner);
    }
}
