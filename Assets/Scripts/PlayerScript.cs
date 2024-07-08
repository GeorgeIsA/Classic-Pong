using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{ 
    public int speed =  10;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.down * Time.deltaTime * speed);


    }
}
