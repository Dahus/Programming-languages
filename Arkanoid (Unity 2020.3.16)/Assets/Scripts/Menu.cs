using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _imageSettings;
    [SerializeField] private GameObject _text;

    private void Start()
    {
        _text.SetActive(false);   
    }
    public void OpenSettings() 
    {
        _imageSettings.SetActive(true);
    }

    public void CloseSettings() 
    {
        _imageSettings.SetActive(false); 
    }
    

    public void LoadSceneGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void ButtonExit() 
    {
        _text.SetActive(true);
    }




}
