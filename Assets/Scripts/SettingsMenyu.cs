using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenyu : MonoBehaviour {

    public AudioMixer audioMix;

    public Dropdown rezDropDown;

    Resolution[] rezSizes;

    void Start()
    {
       rezSizes = Screen.resolutions;

        rezDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentRezIndx = 0;

        for (int i = 0; i < rezSizes.Length; i++)
        {
            string option = rezSizes[i].width + " x " + rezSizes[i].height;
            options.Add(option);

            if(rezSizes[i].width == Screen.currentResolution.width && rezSizes[i].height == Screen.currentResolution.height)
            {
                currentRezIndx = i;
            }
        }

        rezDropDown.AddOptions(options);
        rezDropDown.value = currentRezIndx;
        rezDropDown.RefreshShownValue();
    }

    public void SetRez(int rezIndx)
    {
        Resolution rez = rezSizes[rezIndx];
        Screen.SetResolution(rez.width, rez.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMix.SetFloat("Volume", volume);
    }

    public void SetMyQuality(int qualityIndx)
    {
        QualitySettings.SetQualityLevel(qualityIndx);
    }

    public void ToggleFullScreen(bool IsfullScreen)
    {
        Screen.fullScreen = IsfullScreen;
    }
}
