using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    public Scene targetScene;
    public void ClickPlay()
    {
        SceneManager.LoadScene("Asteroids");
    }
    
    public void ClickPlayPlayground()
    {
        SceneManager.LoadScene("Playground");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
