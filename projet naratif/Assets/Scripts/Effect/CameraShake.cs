using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera mainCamera;
    private Vector3 initialPosition;   
    [SerializeField] float shakeStrength = 0.3f;
    [SerializeField] float shakeTime = 0.3f;

    bool isShaking;
    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        initialPosition = mainCamera.transform.position;
    }

    public void StartShake()
    {
        isShaking = true;
        StartCoroutine(Shake());
        StartCoroutine(StopShaking());
        

    }

    public void StopShake()
    {
        isShaking = false;
        mainCamera.transform.position = initialPosition;
    }

    public IEnumerator Shake()
    {
        while (isShaking)
        {
            Vector3 randomPos = Random.insideUnitCircle * shakeStrength;
            mainCamera.transform.position = initialPosition + randomPos;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(shakeTime);
        StopShake();
    }

}
