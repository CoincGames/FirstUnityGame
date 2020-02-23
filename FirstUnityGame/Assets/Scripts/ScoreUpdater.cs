using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public Text text;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + gameManager.score;
    }
}
