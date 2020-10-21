using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;

    [SerializeField] private Slider volueSlider;

    [SerializeField] private float defaultVolume = 0.5f;
    
    private Resolution[] _resolutions;

    // Start is called before the first frame update
    void Start()
    {
        volueSlider.value = PlayerPrefsController.GetMasterVolume();
        
        ConfigureResolutions();
    }

    void ConfigureResolutions()
    {
        _resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        var options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Insert(0, option);

            if (_resolutions[i].width == Screen.currentResolution.width &&
                _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volueSlider.value);
        }
        else
        {
            Debug.Log("No Music player found..");
        }
    }
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volueSlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void SetDefaults()
    {
        volueSlider.value = defaultVolume;
    }
}
