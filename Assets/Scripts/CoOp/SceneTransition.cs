using UnityEngine;

namespace CoOp
{
    public class SceneTransition : MonoBehaviour
    {
        private Animator _animator;
        private string _scene;
        private const string HubScene = "Scenes/Hub";
        private static SceneTransition _instance;
        private static readonly int Start = Animator.StringToHash("Start");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
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
        
        public static void LoadScene(string scene)
        {
            // start the fade
            _instance._animator.SetTrigger(Start);
            // set the scene index
            _instance._scene = scene;
        }

        public static void LoadHub()
        {
            LoadScene(HubScene);
        }
        
        public void AnimationFinished()
        {
            var fadeOut = _animator.GetCurrentAnimatorStateInfo(0).IsName("Fade Out");
            if (fadeOut)
                return;
            // once the fade has finished, switch to scene
            print($"going to {_scene}");
            UnityEngine.SceneManagement.SceneManager.LoadScene(_scene);
        }
    }
}
