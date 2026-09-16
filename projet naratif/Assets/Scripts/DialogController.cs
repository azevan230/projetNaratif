using System.Collections;
using System.Collections.Generic;
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
        if(!speakerD.ContainsKey(nextLine.speaker)){return;}
        Debug.Log("sa a pas return");
        characterViewRef = speakerD[nextLine.speaker].GetComponent<CharacterView>();
        characterViewRef.setCharacterEmotion(nextLine.emotion);
        if(nextLine.isOnScreen)
        {
            speakerD[nextLine.speaker].SetActive(true);
        }   
        else
        {
            speakerD[nextLine.speaker].SetActive(false);
        }
    }

}
