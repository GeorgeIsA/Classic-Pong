using UnityEngine;
using UnityEngine.UI;

public class WhiteScript : MonoBehaviour
{
    private Button currentButton;
    private Text associatedText;
    private void Start()
    {
        currentButton = gameObject.GetComponent<Button>();
        associatedText = gameObject.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (currentButton.IsHighlighted())
            associatedText.color = Color.white;
        else         
            associatedText.color = Color.black;
        
    }
}


