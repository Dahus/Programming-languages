using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private int points=0;
    [SerializeField] private UIUpdater _uiUpdater;
    
    public void IncreasePoints(int p)
    {
        points = points + p;
        Debug.Log(points);
        //_uiUpdater.UpdateTextPoints(points);
        _uiUpdater.UpdateScore(points);
    }

    public void SubtractPoint(int p) 
    {
        if (points - p >= 0) 
        {
            points = points - p;
            _uiUpdater.UpdateScore(points);
        }
    }

    public int GetPoints() 
    {
        return points;
    }
    
    public void SetPoints(int point) 
    {
        points = point;
        _uiUpdater.UpdateScore(points);
    }
}
