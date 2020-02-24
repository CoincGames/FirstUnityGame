using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Game Object which owns this script.")]
    private GameObject owner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Pickup();
    }

    private void Pickup()
    {
        GameManager.instance.addScore(50);
        Destroy(owner);
    }
}
