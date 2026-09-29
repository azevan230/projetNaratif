using System;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HandbookManager", order = 1)]
public class HandbookController : ScriptableObject
{
    public List<HintModel> discoveredHint;
    void Awake()
    {
        discoveredHint.Clear();
    }
    public void PlayerDiscoverHint(HintModel model)
    {
        discoveredHint.Add(model);  
    }
}
