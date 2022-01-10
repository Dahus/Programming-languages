using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private Toggle _toggleSound;
    [SerializeField] private AudioSource _audio;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AcceptInStartMenu() 
    {
        AcceprSetting();
       
    }
    public void OpenSettings() 
    {
        _sliderVolume.value = _audio.volume;
        _toggleSound.isOn = !_audio.mute;
    }

    public void StartSettings() 
    {
        _audio.volume = PlayerPrefs.GetFloat("Volume");
        int d = PlayerPrefs.GetInt("Sound");

        if (d == 0)
        {
            _audio.mute = false;
        }
        if (d == 1)
        {
            _audio.mute = true;
        }
    }



    public void AcceprSetting()
    {
        int d = 1;
        if (_toggleSound.isOn == true) 
        {
            d = 0;
        }


        PlayerPrefs.SetInt("Sound", d);
        PlayerPrefs.SetFloat("Volume", _sliderVolume.value);
        StartSettings();
    }
}
