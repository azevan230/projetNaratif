using System.Collections;
using System.Collections.Generic;
using LitMotion;
using LitMotion.Extensions;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] DialogView dialogViewRef;
    [SerializeField] List<Scene> scenes;
    [SerializeField] Dictionary<Background, Sprite> backgroundD;
    [SerializeField] Dictionary<Speaker, GameObject> speakerD;
    CharacterView characterViewRef;

    Queue<Scene> scenesQueue;
    Queue<Line> linesQueue;

    
    void Awake()
    {
        scenesQueue = new Queue<Scene>(scenes);
        NextScene();
    }

    public void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if(dialogViewRef.typewriterComponent.IsShowingText)
            {
                dialogViewRef.typewriterComponent.SkipTypewriter();
                return;
            }
            
            
            if (dialogViewRef.characterDialogText.pageToDisplay < dialogViewRef.characterDialogText.textInfo.pageCount)
            {
                dialogViewRef.characterDialogText.pageToDisplay++;
                dialogViewRef.typewriterComponent.StartShowingText();
                return;
            }
            else
            {
                dialogViewRef.characterDialogText.pageToDisplay = 1;
            }
            
            if(linesQueue.Count == 0)
            {
                NextScene();
            }
            else
            {
                NextLine();
            }
            
        }
    }

    void NextScene()
    {   
        Scene nextScene = scenesQueue.Dequeue();
        dialogViewRef.ChangeBackground(backgroundD[nextScene.background]);
        linesQueue = new Queue<Line>(nextScene.line);
        NextLine();
    }

    void NextLine()
    {
        Line nextLine = linesQueue.Dequeue();
        dialogViewRef.ShowLine(nextLine.speaker,nextLine.text,nextLine.color);  
        EffectController.Instance.PlayEffect(nextLine.effect);
        if(!speakerD.ContainsKey(nextLine.speaker)){return;}
        characterViewRef = speakerD[nextLine.speaker].GetComponent<CharacterView>();
        characterViewRef.setCharacterEmotion(nextLine.emotion);
        SpriteRenderer[] characterChild = speakerD[nextLine.speaker].GetComponentsInChildren<SpriteRenderer>();
        if(nextLine.isOnScreen)
        {
            speakerD[nextLine.speaker].SetActive(true);
            LMotion.Create(0.0f,1.0f,0.5f).WithEase(Ease.OutQuad).BindToColorA(speakerD[nextLine.speaker].GetComponent<SpriteRenderer>());
            foreach (SpriteRenderer sprite in characterChild)
            {
                LMotion.Create(0.0f,1.0f,0.5f).WithEase(Ease.OutQuad).BindToColorA(sprite);
            }
        }   
        else
        {
            LMotion.Create(1.0f,0.0f,0.5f).WithEase(Ease.OutQuad).BindToColorA(speakerD[nextLine.speaker].GetComponent<SpriteRenderer>());
            foreach (SpriteRenderer sprite in characterChild)
            {
                LMotion.Create(1.0f,0.0f,0.5f).WithEase(Ease.OutQuad).BindToColorA(sprite);
            }
            StartCoroutine(Disapear(nextLine));
        }
    }

    IEnumerator Disapear(Line nextLine)
    {
        yield return new WaitForSeconds(0.5f);
        speakerD[nextLine.speaker].SetActive(false);
    }

}
