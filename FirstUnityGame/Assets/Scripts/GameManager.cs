using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton for GameManager
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameManager in scene!");
            return;
        }
        instance = this;
    }

    [SerializeField]
    [Tooltip("The UI to display when the level gets completed.")]
    private GameObject displayUIOnLevelComplete;

    public int score { get; set; } = 0;
    [SerializeField]
    [Tooltip("The score required to complete the level.")]
    private int scoreToCompleteLevel = 100;

    public void addScore(int addedScore)
    {
        score += addedScore;
        if (score >= scoreToCompleteLevel)
        {
            displayUIOnLevelComplete.SetActive(true);
        }
    }
}
