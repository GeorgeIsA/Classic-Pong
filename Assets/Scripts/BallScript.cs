using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
