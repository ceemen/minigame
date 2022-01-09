using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

namespace UI
{
    public class OptionsMenu : Menu
    {
        [SerializeField] private Canvas mainMenu;
        [SerializeField] private PlayerInputManager inputManager;

        public AudioMixer audioMixer;

        public void SetVolumeMaster(float volume)
        {
            audioMixer.SetFloat("volume master", volume);
        }
        public void OptionsBack()
        {
            ChangeCanvas(mainMenu);
        }
        public void SetFullscreen (bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
    }
}