using TMPro;
using UnityEngine;

public class placeNameView : MonoBehaviour
{
    [SerializeField] SceneModel Model;
    [SerializeField] TextMeshProUGUI textName;

    void OnEnable()
    {
        textName.text = Model.SceneName;
    }

}
