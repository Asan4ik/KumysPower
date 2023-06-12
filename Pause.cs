using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject ui;
    private bool isPaused = false;
    void Update()
    {
        if (isPaused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            ui.SetActive(true);
        }
        else if(isPaused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = false;
            ui.SetActive(false);
        }
    }
    public void Resume()
    {
        ui.SetActive(false);
        isPaused = false;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
