using UnityEngine;

namespace CoOp
{
    public class SceneTransition : MonoBehaviour
    {
        private Animator _animator;
        private int _sceneIndex;
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
        
        public static void LoadScene(int index)
        {
            // start the fade
            _instance._animator.SetTrigger(Start);
            // set the scene index
            _instance._sceneIndex = index;
        }

        public void AnimationFinished()
        {
            var fadeOut = _animator.GetCurrentAnimatorStateInfo(0).IsName("Fade Out");
            if (fadeOut)
                return;
            // once the fade has finished, switch to scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneIndex);
            print($"going to {_sceneIndex}");
        }
    }
}
