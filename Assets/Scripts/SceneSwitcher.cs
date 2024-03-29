using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private const string TargetScene = "Menu";
    private static bool _started;
    private void Awake()
    {
        var inMenu = SceneManager.GetActiveScene() == SceneManager.GetSceneByName(TargetScene);
        // Switch to menu if haven't started
        if (!_started && !inMenu)
        {
            SceneManager.LoadScene(TargetScene);
            _started = true;
            print("<color=yellow>Automatically switching to main menu</color>");
        }
        else if (inMenu)
            _started = true;
        // Otherwise nothing to do
        else
            Destroy(gameObject);
    }
}
