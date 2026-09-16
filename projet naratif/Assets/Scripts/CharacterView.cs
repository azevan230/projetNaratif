using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] Dictionary<Emotion, Sprite> emotionD;
    [SerializeField] SpriteRenderer face;
    public void setCharacterEmotion(Emotion emotion)
    {
        face.sprite = emotionD[emotion];
    }

}
