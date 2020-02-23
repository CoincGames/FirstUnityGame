using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("Menu");
    }
}
