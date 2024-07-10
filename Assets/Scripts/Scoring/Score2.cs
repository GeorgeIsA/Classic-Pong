using UnityEngine;
using UnityEngine.UI;
public class Score2 : MonoBehaviour
{
    public Text player1ScoreText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Scoring.player1Score++;
            player1ScoreText.text = Scoring.player1Score.ToString();
            Scoring.scored = true;
        }
    }
}
