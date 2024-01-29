using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerControl : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}