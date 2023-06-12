using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionMenu : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}
