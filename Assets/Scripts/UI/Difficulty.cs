using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.UI;

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
    }
    public static void SetDifficultyButton()
    {
        PlayerPrefs.SetInt("Difficulty", difficultyButton.gameObject.GetComponent<UnityEngine.UI.Dropdown>().value);
        
        paddleSlider.value = AdjustSize();
    }
    private static int AdjustSize()
    {
        switch (difficultyNumber)
        {
            case 0:
                return 1;
            case 1:
                return 2;
            case 2:
                return 3;
            default: return 0;
        }
    }
}
