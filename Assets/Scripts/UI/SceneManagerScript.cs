using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagerScript : MonoBehaviour
{
    private static bool inGame;
    private static Slider paddleSlider;
    public static GameObject[] gameHandlerObjectInstance = new GameObject[2];
    public GameHandler gameHandler1;
    public GameHandler gameHandler2;
    public static bool doneInstance = false;
    public static bool is1;
    public static bool is2;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            gameHandlerObjectInstance = GameObject.FindGameObjectsWithTag("GameHandler");
            InitializeGameHandlers();
            if (doneInstance && gameHandlerObjectInstance.Length == 2)
            {
                FindCopy(gameHandler1, gameHandler2);
                if (is1)
                {
                    Destroy(gameHandlerObjectInstance[1]);
                    DontDestroyOnLoad(gameHandlerObjectInstance[0]);
                }
                else if (is2)
                {
                    Destroy(gameHandlerObjectInstance[0]);
                    DontDestroyOnLoad(gameHandlerObjectInstance[1]);
                }
            }
        }
    }

    private void InitializeGameHandlers()
    {
        gameHandler1 = gameHandlerObjectInstance[0].GetComponent<GameHandler>();
        if (gameHandlerObjectInstance.Length == 1 && gameHandlerObjectInstance[0] != null)
        {
            Debug.Log("Found the initial game handler.");
            
            if (!gameHandler1.firstInstance && !doneInstance)
            {
                gameHandler1.firstInstance = true;
                doneInstance = true;
                is1 = true;
                is2 = false;
                DontDestroyOnLoad(gameHandlerObjectInstance[0]);
                Debug.Log("Done Instance");
            }
        }
        else if (gameHandlerObjectInstance.Length == 2 && gameHandlerObjectInstance[1] != null)
        {
            gameHandler2 = gameHandlerObjectInstance[1].GetComponent<GameHandler>();
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
        SetPaddle();
        if (inGame)
        {
            ApplyPaddleSize();
        }
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
            if (is1)
            {
                gameHandlerObjectInstance[0].GetComponent<GameHandler>().enabled = false;
                Debug.Log("handler1 was disabled" + gameHandlerObjectInstance[0].GetComponent<GameHandler>());
            }
            else if (is2)
            {
                gameHandlerObjectInstance[1].GetComponent<GameHandler>().enabled = false;
                Debug.Log("handler2 was disabled"+gameHandlerObjectInstance[1].GetComponent<GameHandler>());
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private static void PushOneScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (is1)
            {
                gameHandlerObjectInstance[0].GetComponent<GameHandler>().enabled = true;
                Debug.Log("handler1 was enabled" + gameHandlerObjectInstance[0].GetComponent<GameHandler>());
            }
            else if (is2)
            {
                gameHandlerObjectInstance[1].GetComponent<GameHandler>().enabled = true;
                Debug.Log("handler2 was enabled" + gameHandlerObjectInstance[1].GetComponent<GameHandler>());
            }
        }
    }

    private static void UISystem()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            BackOneScene();
        }

        if (SceneManager.GetActiveScene().name == "OptionsScene" && !inGame)
        {
            BackOneScene();
        }

        if (SceneManager.GetActiveScene().name == "OptionsScene" && inGame)
        {   
            PushOneScene();
            
        }
    }
}

