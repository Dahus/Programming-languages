using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private string nameBonus;
    [SerializeField] private Color colorBonus;
    [SerializeField] private int points;
     public PointsCounter _pointsCounter;
     public CountBall _countball;
    public PlatformaShoot _platformaShoot;
    public enum objectAdd
    {
        Platforma = 0,
        Ball = 1
    };

    public objectAdd _obj;
    public virtual void BonusActivate() 
    {
        _pointsCounter.IncreasePoints(points);
    }


    public virtual  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformMove>())
        {
            BonusActivate();
        }
        Destroy(gameObject, 3f);
    }

    

    public virtual void SetPointsCounter(PointsCounter counter) 
    {
        _pointsCounter = counter;
    }
}
