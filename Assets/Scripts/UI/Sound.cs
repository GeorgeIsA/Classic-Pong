using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public static Slider volumeSlider;
    public void Awake()
    {
        volumeSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);
    }
    public static void SoundSave()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
