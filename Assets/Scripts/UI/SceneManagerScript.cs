using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
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
    public static GameObject player1;
    public static GameObject player2;
    public static bool inOptions = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" && !inOptions)
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
            if (!gameHandler1.firstInstance && !doneInstance)
            {
                gameHandler1.firstInstance = true;
                doneInstance = true;
                is1 = true;
                is2 = false;
                DontDestroyOnLoad(gameHandlerObjectInstance[0]);
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

    private static void SetPaddle()
    {
        if (inOptions)
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
        if (SceneManager.GetActiveScene().name == "GameScene" && !inOptions)
        {
            player1 = GameObject.Find("Player1");
            player2 = GameObject.Find("Player2");
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

    private IEnumerator BackOneScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            //Debug.Log("Here the game handler should be disabled");
            ToggleGameHandler(false);
            Time.timeScale = 0;
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Additive);
            inOptions = true;
        }
    }

    private IEnumerator PushOneScene()
    {
        //Debug.Log("waiting for escape");
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            //Debug.Log("Esc pressed");
            
            yield return SceneManager.UnloadSceneAsync("OptionsScene");
            inOptions = false;
            Time.timeScale = 1;
            ToggleGameHandler(true);
        }
    }   

    private void UISystem()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" && !inOptions)
        {
            StartCoroutine(BackOneScene());
        }
    }

    private void Update()
    {
        //Debug.Log("inOptions: " + inOptions + " inGame: " + inGame);
        //Debug.Log("inOptions: " + inOptions);
        UISystem();
    }

    private void LateUpdate()
    {
        if (inOptions && inGame)
        {
            
            //Debug.Log("Ready");
            StartCoroutine(PushOneScene());
        }
    }

    private static void ToggleGameHandler(bool state)
    {
        foreach (var handler in gameHandlerObjectInstance)
        {
            if (handler != null)
            {
                //Debug.Log("This is where it gets killed");
                handler.SetActive(state);
            }
        }
    }
}
