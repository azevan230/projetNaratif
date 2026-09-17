using System;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LineScriptableObject", order = 1)]
public class Line : ScriptableObject
{
    public Speaker speaker;
    public string text;
    public Emotion emotion;
    public Color color;
    public bool isOnScreen;
    public Effect effect;
}
