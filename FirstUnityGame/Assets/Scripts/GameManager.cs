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

    // Start properties for GameManager object
    public GameObject completeLevelUI;
    public int score { get; set; }
    public int goal = 100;

    public void addScore(int addedScore)
    {
        score += addedScore;
        if (score >= goal)
        {
            completeLevelUI.SetActive(true);
        }
    }
}
