using UnityEngine;

public class HandbookView : MonoBehaviour
{
    [SerializeField] private GameObject discoverHintPrefab;
    [SerializeField] private HandbookController model;
    void OnEnable()
    {
        foreach(HintModel hint in model.discoveredHint)
        {
            GameObject go = Instantiate(discoverHintPrefab,gameObject.transform);
            go.GetComponent<HintView>().Initialize(hint);
        }
    }
    void OnDisable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        } 
    }
}
