using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public static int difficultyNumber;
    public static GameObject difficultyButton;
    public static Slider paddleSlider;
    private void Awake()
    {
        difficultyNumber = PlayerPrefs.GetInt("Difficulty", 0);
        difficultyButton = GameObject.Find("DifficultyDropdown");
        paddleSlider = GameObject.Find("PaddleSizeSlider").GetComponent<Slider>();
        difficultyButton.gameObject.GetComponent<UnityEngine.UI.Dropdown>().value = difficultyNumber;
        paddleSlider.value = PlayerPrefs.GetFloat("PaddleSize", 1);
        
    }
    public static void SetDifficultyButton()
    {
        difficultyNumber = difficultyButton.gameObject.GetComponent<UnityEngine.UI.Dropdown>().value;
        PlayerPrefs.SetInt("Difficulty", difficultyNumber);
        //Debug.Log(difficultyNumber);
        paddleSlider.value = AdjustSize();
    }
    private static int AdjustSize()
    {
        switch (difficultyNumber)
        {
            case 0:
                return 3;
            case 1:
                return 2;
            case 2:
                return 1;
            default: return 0;
        }
    }
}
