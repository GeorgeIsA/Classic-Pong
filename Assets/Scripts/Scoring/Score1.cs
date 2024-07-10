using UnityEngine;
using UnityEngine.UI;
public class Score1 : MonoBehaviour
{
    public Text player2ScoreText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Scoring.player2Score++;
            player2ScoreText.text = Scoring.player2Score.ToString();
            Scoring.scored = true;
        }
    }

}
