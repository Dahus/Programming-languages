using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterBonus : MonoBehaviour
{

    [SerializeField] private Bonus[] _bonus;
    [SerializeField] private CountBall _countBall;
    [SerializeField] private PlatformaShoot _platformaShoot;
    [SerializeField] private PointsCounter _pointsCounter;
    
    public void CreateBonus(Transform _pos) 
    {
        float randBonusCreate = Random.Range(0, 5);
        if (randBonusCreate >= 3) 
        {
            int randBonus = Random.Range(0, 7);
            Bonus bonus = Instantiate(_bonus[randBonus], _pos.transform.position, Quaternion.identity);
            if (bonus._obj == Bonus.objectAdd.Ball)
            {
                bonus._countball = _countBall;
                bonus._pointsCounter = _pointsCounter;
            }
            if (bonus._obj == Bonus.objectAdd.Platforma)
            {
                bonus._platformaShoot = _platformaShoot;
                bonus._pointsCounter = _pointsCounter;
            }
        }
        
        
    }
}
