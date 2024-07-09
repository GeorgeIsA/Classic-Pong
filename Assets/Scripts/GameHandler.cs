using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject ballObject;

    [SerializeField] public bool onRandom;

    float playerSpeed;

    Rigidbody2D ballrb;
    private void Awake()
    {
        ballrb = ballObject.GetComponent<Rigidbody2D>();
        playerSpeed = PlayerScript.globalSpeed;
    }
    private void Start()
    {
        int firstDirection = Random.Range(0, 2);
        if (firstDirection == 0 && onRandom)
            ballrb.velocity = new Vector2(1, 0) * playerSpeed;
        else
            ballrb.velocity = new Vector2(-1, 0) * playerSpeed;

    }
}
