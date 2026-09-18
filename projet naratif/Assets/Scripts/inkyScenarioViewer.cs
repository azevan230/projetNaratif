using System.Collections.Generic;
using Ink.Runtime;
using Ink.UnityIntegration;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class inkyScenarioViewer : MonoBehaviour
{
    [SerializeField] private InkFile scenarioFile;
    [SerializeField] private TextMeshProUGUI storyLineTMP;
    [SerializeField] List<Button> choixTexte;
    private Story story;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        story = new Story(scenarioFile.storyJson);
        storyLineTMP.text = story.Continue();
    }

    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if(story.canContinue)
            {
                ShowNextLine();
            }
            ShowChoiceButtons();
        }
    }

    void OnClickButton(int i)
    {
        story.ChooseChoiceIndex(i);
        HideChoiceButton();
        ShowNextLine();
        ShowChoiceButtons();
    }
    void ShowNextLine()
    {
        storyLineTMP.text = story.Continue();
    }

    void ShowChoiceButtons()
    {
        if(story.currentChoices.Count > 0)
        {
            for(int i = 0; i< story.currentChoices.Count;i++)
            {
                int index = i;
                Choice choice = story.currentChoices[i];
                choixTexte[i].gameObject.SetActive(true);
                choixTexte[i].GetComponentInChildren<TextMeshProUGUI>().SetText(choice.text);
                choixTexte[i].onClick.AddListener(() => OnClickButton(index));
            }
        }
    }

    void HideChoiceButton()
    {
        foreach(Button bouton in choixTexte)
        {
            bouton.gameObject.SetActive(false);
            bouton.onClick.RemoveAllListeners();
        }
    }
}
