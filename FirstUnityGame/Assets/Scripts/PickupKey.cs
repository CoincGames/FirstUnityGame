using System.Collections;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Game Object which owns this script. (Used to destroy the object)")]
    private GameObject owner;

    [SerializeField]
    [Tooltip("The door to unlock when this key is picked up.")]
    private GameObject associatedDoor;

    [SerializeField]
    [Tooltip("The effect to play when key is picked up.")]
    private GameObject pickupEffect;

    [SerializeField]
    [Range(.25f, 5f)]
    [Tooltip("The duration in seconds of the fade animation on the door.")]
    private float fadeDuration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Pickup();
    }

    private void Pickup()
    {
        // Play the effect at given position with given rotation
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Make the key disappear
        owner.GetComponent<Renderer>().enabled = false;
        owner.GetComponent<Collider>().enabled = false;

        // Enable clipping through the door
        associatedDoor.GetComponent<Collider>().enabled = false;

        // Fade the container gameObject
        StartCoroutine(BeginFade(associatedDoor.GetComponent<Renderer>().material));
        // Fade any of its children (MUST BE IN FADE RENDER MODE TO FADE OUT)
        foreach (Renderer renderer in associatedDoor.GetComponentsInChildren<Renderer>())
        {
            foreach (Material mat in renderer.materials)
            {
                StartCoroutine(BeginFade(mat));
            }
        }

        // Delete the extra objects left after unrendered
        StartCoroutine(DeleteObjects());
    }

    private IEnumerator BeginFade(Material material)
    {
        // Cache the current color of the material, and its initiql opacity.
        Color color = material.color;
        float startOpacity = color.a;

        // Track how many seconds we've been fading.
        float t = 0;

        while (t < fadeDuration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / fadeDuration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity, 0, blend);

            // Apply the resulting color to the material.
            material.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }

    private IEnumerator DeleteObjects()
    {
        yield return new WaitForSeconds(fadeDuration);
        Destroy(owner);
        Destroy(associatedDoor);
    }
}