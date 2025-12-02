using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
