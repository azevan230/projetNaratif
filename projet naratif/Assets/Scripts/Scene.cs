using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneScriptableObject", order = 1)]
public class Scene : ScriptableObject
{
    [SerializeField] List<Line> lines;
    [SerializeField] Background background;
}
