using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class DialogView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI characterDialogText;
    [SerializeField] SpriteRenderer background;



    public void ShowLine(Speaker speaker, string text, Color color)
    {
        characterName.SetText(speaker.ToString());
        characterDialogText.SetText(text);
        characterDialogText.color = color;   
    }

    public void ChangeBackground(Sprite newBackground)
    {
        background.sprite = newBackground;
    }

    

}
