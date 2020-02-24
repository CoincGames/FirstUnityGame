using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text UI element to update the score on.")]
    private Text uiTextElement;

    // Update is called once per frame
    void Update()
    {
        uiTextElement.text = "Score: " + GameManager.instance.score;
    }
}
