using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagerScript : MonoBehaviour
{
    private static bool inGame;
    private static bool isPaused = false;
    private static Slider paddleSlider;

    private void Awake()
    {
        SetPaddle();
        if (inGame)
            ApplyPaddleSize();
    }
    private void Update()
    {
        UISystem();
    }
    private static void SetPaddle()
    {
        if (SceneManager.GetActiveScene().name == "OptionsScene")
        {
            paddleSlider = GameObject.Find("PaddleSizeSlider").GetComponent<Slider>();
            paddleSlider.value = PlayerPrefs.GetFloat("PaddleSize", 2.5f);
        }
    }

    public static void SetPaddleSize()
    {
        PlayerPrefs.SetFloat("PaddleSize", paddleSlider.value);
    }

    private static void ApplyPaddleSize()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            GameObject player1 = GameObject.Find("Player1");
            GameObject player2 = GameObject.Find("Player2");
            player1.transform.localScale = new Vector3(0.5f, PlayerPrefs.GetFloat("PaddleSize", 2.5f), 1);
            player2.transform.localScale = new Vector3(0.5f, PlayerPrefs.GetFloat("PaddleSize", 2.5f), 1);
        }
    }
    public static void PlayPush()
    {
        inGame = true;
        SceneManager.LoadScene("GameScene");
    }
    public static void OptionsPush()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public static void ExitPush()
    {
        Application.Quit();
    }
    public static void BackPush()
    {
        SceneManager.LoadScene("MenuScene");
        inGame = false;
    }
    private static void BackOneScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckPause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }
    private static void PushOneScene()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            CheckPause();
        }
    }
    private static void CheckPause()
    {
        if (isPaused && inGame)
            UnPause();
        else Pause();
    }

    public static void Pause()
    {
        Debug.Log("Pause");
        isPaused = true;
        Time.timeScale = 0;
    }
    public static void UnPause()
    {
        Debug.Log("UnPause");
        isPaused = false;
        Time.timeScale = 1;
    }
  
    private static void UISystem()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
            BackOneScene();
        if (SceneManager.GetActiveScene().name == "OptionsScene" && !inGame)
            BackOneScene();
        if (SceneManager.GetActiveScene().name == "OptionsScene" && inGame)
            PushOneScene();
    }
}
public class General
{
    public static GameObject player1;
    public static GameObject player2;
}

