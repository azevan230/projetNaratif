using UnityEngine;

public class EffectController : MonoBehaviour
{
    public static EffectController Instance { get; private set; }

    [SerializeField] CameraShake cameraShake;
    [SerializeField] ColorFade colorFade;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void PlayEffect(Effect effect)
    {
        switch(effect)
        {
            case Effect.none:
            break;
            case Effect.Shaking:
                cameraShake.StartShake();
                Debug.Log("sa shake");
                break;
            case Effect.FadeFromBlack:
                colorFade.FadeFromBlack();
                break;
            case Effect.FadeToBlack:
                colorFade.FadeToBlack();
                break;
            case Effect.flash:
                colorFade.Flash();
                break;
            default:
                break;
        }
    }
    
}
