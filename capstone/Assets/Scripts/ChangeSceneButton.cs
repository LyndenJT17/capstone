using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    public void OnButtonClicked()
    {
        SceneManager.LoadScene(sceneName); // Load the scene when the button is clicked
    }
}