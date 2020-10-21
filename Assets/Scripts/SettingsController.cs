using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    [SerializeField] private Slider volueSlider;

    [SerializeField] private float defaultVolume = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        volueSlider.value = PlayerPrefsController.GetMasterVolume();
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
