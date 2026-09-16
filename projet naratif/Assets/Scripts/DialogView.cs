using System;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DialogView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI characterDialogText;

    public void ShowLine(Speaker speaker, string text)
    {
        characterName.SetText(speaker.ToString());
        characterDialogText.SetText(text);
    }

}
