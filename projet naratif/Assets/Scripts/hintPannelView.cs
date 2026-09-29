using System.Collections.Generic;
using UnityEngine;

public class hintPannelView : MonoBehaviour
{
    [SerializeField] private RectTransform hintList;
    [SerializeField] private GameObject hintViewPrefab;
    [SerializeField] private List<HintModel> hintModels;

    private void Awake()
    {
        foreach(HintModel model in hintModels)
        {
            GameObject go = Instantiate(hintViewPrefab,hintList.transform);
            go.GetComponent<HintView>().Initialize(model);
        }
    }
}
