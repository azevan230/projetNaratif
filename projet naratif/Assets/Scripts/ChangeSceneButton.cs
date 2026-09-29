using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] SceneModel model;
    [SerializeField] TextMeshProUGUI sceneName;
    void OnEnable()
    {
        sceneName.text = model.SceneName;
    }

    public void OnCLick()
    {
        SceneManager.LoadScene(model.SceneName);
    }
}
