using UnityEngine;

namespace CoOp
{
    public class SceneTransition : MonoBehaviour
    {
        private static SceneTransition _instance;
        
        private void Awake()
        {
            // If player manager doesn't already exist, make this the singleton.
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            // Otherwise delete this clone.
            Destroy(gameObject);
        }

        public static void LoadScene(int index)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }
    }
}
