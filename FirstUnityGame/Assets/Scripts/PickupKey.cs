using System.Collections;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public GameObject owner;
    public GameObject associatedDoor;

    public float fadeDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        // Make the key disappear
        owner.GetComponent<Renderer>().enabled = false;

        // Enable clipping through the door
        associatedDoor.GetComponent<Collider>().enabled = false;

        // Fade the container gameObject
        StartCoroutine(BeginFade(associatedDoor.GetComponent<Renderer>().material));
        // Fade any of its children (MUST BE IN FADE RENDER MODE TO FADE OUT)
        foreach(Renderer renderer in associatedDoor.GetComponentsInChildren<Renderer>())
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