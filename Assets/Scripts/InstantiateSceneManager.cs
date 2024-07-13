using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateSceneManager : MonoBehaviour
{
    public GameObject SceneManagerPref;
    public void Awake()
    {
        if (SceneManager.GetActiveScene().name == "OptionsScene")
        {
            Instantiate(SceneManagerPref, new Vector2(0, 0), Quaternion.identity);
            SceneManagerScript.inOptions = true;
        }
        }
    }
