using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonPress : MonoBehaviour
{
    public void Press()
    {
        SceneManager.LoadScene("Level1");
    }
}
