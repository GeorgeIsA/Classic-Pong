using UnityEngine;
using System.Collections;
public class Scoring : MonoBehaviour
{
    public static int player1Score;
    public static int player2Score;
    public static bool scored;
    public GameObject blueWin;
    public GameObject redWin;
     public int maxScore;

    public GameObject ball;
    
    private GameHandler gameHandler;

    private void Start()
    {
        //Debug.Log(blueWin);
        scored = false;
        player1Score = 0;
        player2Score = 0;
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void Update()
    {
        if (player1Score == maxScore)
        {
            blueWin.SetActive(true);
            Debug.Log("Blue Wins");
            StartCoroutine(DelayRestart2(blueWin));
        }
        if (player2Score == maxScore)
        {
            redWin.SetActive(true);
            Debug.Log("Red Wins");
            StartCoroutine(DelayRestart2(redWin));
        }
        if (scored)
        {
            //ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            StartCoroutine(DelayRestart());
            scored = false;
        }
        
    }

    private IEnumerator DelayRestart() 
    {
        yield return new WaitForSeconds(1f);
        gameHandler.Restart();
    }
    private IEnumerator DelayRestart2(GameObject playerText)
    {
        Debug.Log("works");
        yield return new WaitForSeconds(3f);
        playerText.SetActive(false);
        player1Score = 0;
        player2Score = 0;
    }

}
