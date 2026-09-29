using TMPro;
using UnityEngine;

public class HintView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private HandbookController handbookController;
    private HintModel currentHint;

    public void Initialize(HintModel model)
    {
        hintText.text = model.hintName;
        currentHint = model;
    }

    public void OnClick()
    {
        handbookController.PlayerDiscoverHint(currentHint);
        Destroy(gameObject);
    }
}
