using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    [SerializeField] private GameObject _pausaUI;
    [SerializeField] private bool _isPausa=false;
    [SerializeField] private Settings _settings;
    public void PausaOn() 
    {
        Time.timeScale = 0;
        _pausaUI.SetActive(true);
        _isPausa = true;
    }

    public void PausaOFF() 
    {
        Time.timeScale = 1;
        _pausaUI.SetActive(false);
        _isPausa = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isPausa == false) 
        {
            PausaOn();
        }
        else if(Input.GetKeyDown(KeyCode.Escape)&& _isPausa == true) 
        {
            _settings.AcceprSetting();
            PausaOFF();
        }
    }

}
