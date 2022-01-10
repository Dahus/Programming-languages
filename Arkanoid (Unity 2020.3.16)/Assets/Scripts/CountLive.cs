using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CountLive : MonoBehaviour
{
   [SerializeField] private Createrlevel _createrLevel;
   [SerializeField] private UIUpdater _uIUpdater;
   [SerializeField] private CountBall _countBall;
 
   [SerializeField] private int _live;
    [SerializeField] private SaveSystem _saveSystem;

    private void Start()
    {
        _uIUpdater.UpdateBall(_live);
    }
    public void UpdateCountLive() 
    {
        
        _live--;
        _uIUpdater.UpdateBall(_live);
        _countBall.CreateBall();
        if (_live <= 0) 
        {
            Defeat();
        }
    }

    public int GetLive()
    {
        return _live;
    }
    public void Defeat()
    {

        SceneManager.LoadScene("StartScene");
        _saveSystem.RestartData();
    }

    public void SetLive(int live) 
    {
        _live = live;
        _uIUpdater.UpdateBall(_live);
    }



}
