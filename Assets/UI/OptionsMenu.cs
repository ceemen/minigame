using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Linq;

namespace UI
{
    public class OptionsMenu : Menu
    {
        [SerializeField] private Canvas mainMenu;
        [SerializeField] private PlayerInputManager inputManager;

        public TMPro.TMP_Dropdown resolutionDropdown;

        Resolution[] resolutions;

        void Start()
        {
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height + " - " + resolutions[i].refreshRate + "Hz";
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        }

        public AudioMixer musicMixer;

        public void SetMusicVolume (float volume)
        {
            musicMixer.SetFloat("music volume", volume);
        }

        public AudioMixer soundsMixer;

        public void SetSoundsVolume(float volume)
        {
            soundsMixer.SetFloat("sounds volume", volume);
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