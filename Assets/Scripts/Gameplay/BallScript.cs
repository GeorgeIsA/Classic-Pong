using UnityEngine;

public class BallScript : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private AudioSource audioSource;
    public AudioClip hitSound;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
        hitSound.LoadAudioData();
    }
    private void OnBecameVisible()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume", 1f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.PlayOneShot(hitSound);
        //Debug.Log("Hit");
        float playerY = other.gameObject.transform.position.y;
        float ballY = gameObject.transform.position.y;
        if (other.collider.CompareTag("Player"))
                rb2d.velocity = new Vector2(checkX(rb2d), checkSide(ballY, playerY)) * PlayerScript.globalSpeed;
        else if (other.collider.CompareTag("edge"))
                rb2d.velocity = new Vector2(checkX(rb2d), checkY(rb2d)) * PlayerScript.globalSpeed;
    }

    private float checkSide(float ballY, float playerY)
    {
        return ballY - playerY;
    }

    private int checkX(Rigidbody2D rb2d)
    {
        if (rb2d.velocity.x > 0)
            return 1;
        else
            return -1;
    }

    private int checkY(Rigidbody2D rb2d)
    {
        if (rb2d.velocity.y > 0)
            return 1;
        else
            return -1;
    }
}

