using TMPro;
using UnityEngine;

public class InfluencerView : MonoBehaviour
{
    [Header("Internal Prefab References")]
    [SerializeField] TextMeshProUGUI nameValue;
    [SerializeField] TextMeshProUGUI productValue;
    [SerializeField] TextMeshProUGUI sloganValue;

    [Header ("Data")]
    [SerializeField] influencerModel model;

    private void OnEnable()
    {
        nameValue.text=model.influencerName;
        productValue.text=model.ProductName;
        sloganValue.text=model.sloganName;
    }


}
