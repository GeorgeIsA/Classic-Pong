using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    static bool inGame;
    public void PlayPush()
    {
        inGame = true;
        SceneManager.LoadScene("GameScene"); 
    }
    public void OptionsPush()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    public void ExitPush()
    {
        Application.Quit();
    }
    public void BackPush()
    {
        SceneManager.LoadScene("MenuScene");
        inGame = false;
    }
    private void BackOneScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void PushOneScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        Debug.Log(inGame);
        if (SceneManager.GetActiveScene().name == "GameScene")
            BackOneScene();
        if (SceneManager.GetActiveScene().name == "OptionsScene" && !inGame)
            BackOneScene();
        if (SceneManager.GetActiveScene().name == "OptionsScene" && inGame)
            PushOneScene();
    }
}

