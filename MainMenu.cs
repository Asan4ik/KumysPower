using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Connection menu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Authors()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Exit()
    {
        Application.Quit();
    }
}