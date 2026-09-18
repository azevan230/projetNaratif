using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour
{
    [SerializeField] private Image fader;
    [SerializeField] private float fadeDuration = 0.3f;
    [SerializeField] private float flashDuration = 0.08f;

    public void FadeToBlack()
    {
        fader.color = Color.black;
        LMotion.Create(0.0f,1.0f,fadeDuration).WithEase(Ease.InQuart).BindToColorA(fader);
    }

    public void FadeFromBlack()
    {
        fader.color = Color.black;
        LMotion.Create(1.0f,0.0f,fadeDuration).WithEase(Ease.InQuart).BindToColorA(fader);
    }

    public void Flash()
    {
        fader.color = Color.white;
        LMotion.Create(0.0f,1.0f,flashDuration).WithLoops(2,LoopType.Yoyo).BindToColorA(fader);
    }
}
