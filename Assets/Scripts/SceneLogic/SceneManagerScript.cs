using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class SceneManagerScript : MonoBehaviour
{
    public static Slider paddleSlider;
    public static GameObject[] gameHandlerObjectInstance = new GameObject[2];
    public GameHandler gameHandler1;
    public GameHandler gameHandler2;
    public static bool doneInstance = false;
    public static bool inGame = false;
    public static bool inOptions = false;
    public static bool is1;
    public static bool is2;
    public static GameObject player1;
    public static GameObject player2;
    public static GameObject ball;
    public GameObject eventSystemGame;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" && !inOptions)
        {
            SetupGameScene();
        }
    }

    private void SetupGameScene()
    {
        ball = GameObject.Find("Ball");
        gameHandlerObjectInstance = GameObject.FindGameObjectsWithTag("GameHandler");
        InitializeGameHandlers();
        if (doneInstance && gameHandlerObjectInstance.Length == 2)
        {
            FindCopy(gameHandler1, gameHandler2);
            DestroyUnnecessaryGameHandler();
        }
    }

    private void DestroyUnnecessaryGameHandler()
    {
        if (is1)
            Destroy(gameHandlerObjectInstance[1]);
        else if (is2)
            Destroy(gameHandlerObjectInstance[0]);
    }

    private void InitializeGameHandlers()
    {
        gameHandler1 = gameHandlerObjectInstance[0].GetComponent<GameHandler>();
        if (gameHandlerObjectInstance.Length == 1 && gameHandlerObjectInstance[0] != null)
        {
            SetupFirstInstance();
        }
        else if (gameHandlerObjectInstance.Length == 2 && gameHandlerObjectInstance[1] != null)
        {
            gameHandler2 = gameHandlerObjectInstance[1].GetComponent<GameHandler>();
        }
    }

    private void SetupFirstInstance()
    {
        if (!gameHandler1.firstInstance && !doneInstance)
        {
            gameHandler1.firstInstance = true;
            doneInstance = true;
            is1 = true;
            is2 = false;
            DontDestroyOnLoad(gameHandlerObjectInstance[0]);
        }
    }

    void FindCopy(GameHandler subject1, GameHandler subject2)
    {
        if (subject1.firstInstance)
        {
            DontDestroyOnLoad(subject1.gameObject);
            is1 = true;
            is2 = false;
        }
        else
        {
            DontDestroyOnLoad(subject2.gameObject);
            is1 = false;
            is2 = true;
        }
    }

    private void Awake()
    {
        if (inOptions)
        {
            SetupOptionsScene();
        }
        if (inGame && !inOptions)
        {
            SetupGamePlayers();
        }
    }

    private void SetupOptionsScene()
    {
        paddleSlider = GameObject.Find("PaddleSizeSlider").GetComponent<Slider>();
        paddleSlider.value = PlayerPrefs.GetFloat("PaddleSize", 1);
    }

    private void SetupGamePlayers()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        ApplyPaddleSize();
    }

    private static void ApplyPaddleSize()
    {
        float paddleSize = PlayerPrefs.GetFloat("PaddleSize", 1);
        Vector2 scale = new Vector2(0.5f, paddleSize);
        player1.transform.localScale = scale;
        player2.transform.localScale = scale;
    }

    public static void PlayPush()
    {
        SceneManager.LoadScene("GameScene");
        inGame = true;
    }

    public static void OptionsPush()
    {
        SceneManager.LoadScene("OptionsScene");
        inOptions = true;
    }

    public static void ExitPush()
    {
        Application.Quit();
    }

    public static void BackPush()
    {
        inOptions = false;
        inGame = false;
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("PaddleSize", paddleSlider.value);
        SceneManager.LoadScene("MenuScene");
        Destroy(gameHandlerObjectInstance[0]);
    }

    private IEnumerator BackOneScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            ball.GetComponent<Renderer>().enabled = false;
            Time.timeScale = 0;
            eventSystemGame.SetActive(false);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Additive);
            ToggleGameHandler(false);
            inOptions = true;

            SetupOptionsScene();
        }
    }

    private IEnumerator PushOneScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetFloat("PaddleSize", paddleSlider.value);
            yield return SceneManager.UnloadSceneAsync("OptionsScene");
            inOptions = false;
            ApplyPaddleSize();
            Time.timeScale = 1;
            ToggleGameHandler(true);
            ball.GetComponent<Renderer>().enabled = true;
        }
    }

    private void UISystem()
    {
        if (inOptions && !inGame && Input.GetKeyDown(KeyCode.Escape))
        {
            inOptions = false;
            PlayerPrefs.SetFloat("PaddleSize", paddleSlider.value);
            SceneManager.LoadScene("MenuScene");
        }
        if (inGame && !inOptions)
            StartCoroutine(BackOneScene());
    }

    private void Update()
    {
        UISystem();
    }

    private void LateUpdate()
    {
        if (inOptions && inGame)
        {
            StartCoroutine(PushOneScene());
        }
    }

    private static void ToggleGameHandler(bool state)
    {
        foreach (var handler in gameHandlerObjectInstance)
        {
            if (handler != null)
                handler.SetActive(state);
        }
    }
}
