using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIUpdater : MonoBehaviour
{

    [SerializeField] private Text _level;
    [SerializeField] private Text _score;
    [SerializeField] private Text _live;
    [SerializeField] private Text _bonus;
    

    public void UpdateLevel(int level)
    {
        _level.text ="Level: "+ level.ToString();
    }

    public void UpdateScore(int score) 
    {
        _score.text ="Score: " + score.ToString();
    }

    public void UpdateBall(int ball) 
    {
        _live.text ="Live: "+ ball.ToString();
    }

    

}
