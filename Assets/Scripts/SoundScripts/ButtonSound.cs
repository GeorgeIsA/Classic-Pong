using UnityEngine;
public class ButtonSound : MonoBehaviour
{
    private static AudioSource audioSource;
    public static AudioClip audioClip;
    public static bool lastInoptions;

    private void Update()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Sounds/ButtonClick");
    }
    public void OnClick()
    {
        audioClip.LoadAudioData();
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat("volume", 1f);
            audioSource.PlayOneShot(audioClip);
        }
    }
}
