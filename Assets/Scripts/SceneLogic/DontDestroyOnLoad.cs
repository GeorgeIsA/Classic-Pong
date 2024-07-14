using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    GameObject[] updatedBackground;
    GameObject[] updatedBackground2;
    private void Awake()
    {
        updatedBackground = GameObject.FindGameObjectsWithTag("ButtonSounds");
        if (updatedBackground.Length == 1 && gameObject.CompareTag("ButtonSounds"))
            DontDestroyOnLoad(this);
        updatedBackground2 = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if (updatedBackground.Length == 1 && gameObject.CompareTag("BackgroundMusic"))
            DontDestroyOnLoad(this);
    }
    private void Update()
    {
        updatedBackground = GameObject.FindGameObjectsWithTag("ButtonSounds");
        if (updatedBackground.Length > 1)
            Destroy(updatedBackground[1]);

        updatedBackground2 = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if (updatedBackground2.Length > 1)
            Destroy(updatedBackground2[1]);
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume", 1f);
    }
}

