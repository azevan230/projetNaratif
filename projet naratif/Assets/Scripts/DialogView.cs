using System;
using Febucci.TextAnimatorForUnity;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class DialogView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI characterName;
    public TextMeshProUGUI characterDialogText;
    public TypewriterComponent typewriterComponent;
    [SerializeField] SpriteRenderer background;



    public void ShowLine(Speaker speaker, string text, Color color)
    {
        characterName.SetText(speaker.ToString());
        typewriterComponent.ShowText(text);
        characterDialogText.color = color;   
    }

    public void ChangeBackground(Sprite newBackground)
    {
        background.sprite = newBackground;
    }

    

}
