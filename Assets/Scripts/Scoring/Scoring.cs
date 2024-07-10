using UnityEngine;
using System.Collections;
public class Scoring : MonoBehaviour
{
    public static int player1Score;
    public static int player2Score;
    public static bool scored;

    public GameObject ball;
    
    private GameHandler gameHandler;

    private void Start()
    {
        scored = false;
        player1Score = 0;
        player2Score = 0;
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void Update()
    {
        if (scored)
        {
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            StartCoroutine(DelayRestart());
            scored = false;
        }
    }

    private IEnumerator DelayRestart() 
    {
        yield return new WaitForSeconds(1f);
        gameHandler.Restart();
    }

}
