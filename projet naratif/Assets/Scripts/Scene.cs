using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneScriptableObject", order = 1)]
public class Scene : ScriptableObject
{
    [SerializeField] public List<Line> line;
    [SerializeField] public Background background;

}
