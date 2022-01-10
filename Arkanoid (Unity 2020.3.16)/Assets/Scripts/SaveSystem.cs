using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private CountLive _countLive;
    [SerializeField] private PointsCounter _pointsCounter;
    [SerializeField] private Createrlevel _levelCreater;
    [SerializeField] private bool isNewInfo;
    private void Start()
    {
        Load();
    }

    public void Save() 
    {
        PlayerPrefs.SetInt("Live", _countLive.GetLive());
        PlayerPrefs.SetInt("Points", _pointsCounter.GetPoints());
        PlayerPrefs.SetInt("Level", _levelCreater.GetLevel());
    }

    public void Load() 
    {
        
        if (PlayerPrefs.GetInt("Live") == 0)
        {
            RestartData();
        }

        if (isNewInfo == true)
        {
            NewInfo();
        }
        _countLive.SetLive(PlayerPrefs.GetInt("Live"));
       _pointsCounter.SetPoints(PlayerPrefs.GetInt("Points"));
        _levelCreater.SetLevel(PlayerPrefs.GetInt("Level"));
    }

    public void RestartData() 
    {
        PlayerPrefs.SetInt("Live", 5);
        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.SetInt("Level", 0);
    }

    public void NewInfo() 
    {
        PlayerPrefs.SetInt("Live", 5);
        PlayerPrefs.SetInt("Points", 300);
        PlayerPrefs.SetInt("Level",5);
    }

}
