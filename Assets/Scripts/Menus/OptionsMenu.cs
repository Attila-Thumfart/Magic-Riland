using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    //The UI Elements required by this script can be dragged in here via the Inspector

    [SerializeField]
    protected AudioMixer audioMixer;

    [SerializeField]
    protected Slider volumeSlider;

    [SerializeField]
    protected TMP_Dropdown qualityDropdown;

    [SerializeField]
    protected TMP_Dropdown resolutionDropdown;

    [SerializeField]
    protected Toggle fullscreenToggle;

    protected int screenState;

    private bool isFullscreen = false;

    //An array to fill with the available resolutions of the screen currently used
    Resolution[] resolutions;

    //These are to store the information of each UI Element when the Application is closed or another scene is loaded
    const string qualitySaveBucket = "qualityValue";
    const string resolutionSaveBucket = "resolutionValue";

    private void Awake()
    {
        screenState = PlayerPrefs.GetInt("togglestate");   // Checks if the screen is in Fullscreen

        if (screenState == 1)                              // Activates the Toggle UI Element if 
        {
            isFullscreen = true;
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>  // Checks if there are any previously safed states for this UI and loads them if that is the case
        {
            PlayerPrefs.SetInt(resolutionSaveBucket, resolutionDropdown.value);
            Save();
        }));

        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>    // Checks if there are any previously safed states for this UI and loads them if that is the case
        {
            PlayerPrefs.SetInt(qualitySaveBucket, qualityDropdown.value);
            Save();
        }));
    }

    private void Start()
    {
        // Changes the Volume to the saved value
        volumeSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MVolume"));

        //Sets the quality to the previously saved option if there is one
        qualityDropdown.value = PlayerPrefs.GetInt(qualitySaveBucket, 5);

        //fills the array with all available resolutions for the currently used screen
        resolutions = Screen.resolutions;

        //clears the preconfigured placeholder-options in the dropdown menu
        resolutionDropdown.ClearOptions();

        //the list is filled with the strings that are meant to be shown in the dropdown menu
        List<string> options = new List<string>();

        //the index in the dropdown menu of unity where the options are listed (starts at 0)
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            //adds the different resolutions options to the list
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            //figures out the standard (maximum) resolution of the used screen when starting the application
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //adds the options saved in the list to the actual dropdown menu
        resolutionDropdown.AddOptions(options);
        //sets the resolution to the standard (maximum) resolution when starting the application
        resolutionDropdown.value = PlayerPrefs.GetInt(resolutionSaveBucket, currentResolutionIndex);
        //refreshes the dropdown menu so the right resolution option is shown
        resolutionDropdown.RefreshShownValue();
    }

    //resolutionIndex is set by the dropdown menu in unity
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //changes the volume of the unity audioMixer
    //float volume is set by the slider(value) in unity
    public void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MVolume"));
    }

    //changes the quality to one of the predetermined options of unity using the dropdown menu as index
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //isFullscreen value set by unity toggle function
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if (isFullscreen == false)
        {
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isFullscreen = true;
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }
}
