using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGun : Bonus
{
    //public CountBall _countball;
  
    enum Gun
    {
        Shoot = 0,
        SuperShoot = 1,
        CancelShoot=2
    };

    [SerializeField] private Gun _gun;
    public override void BonusActivate()
    {
        base.BonusActivate();
        int choose = (int)_gun;
        switch (choose)
        {
            case 0:
                {
                    _platformaShoot.BonusShoot();
                    Debug.Log("shoot");
                    break;
                }
            case 1:
                {
                    _platformaShoot.BonusSuperShoot();
                    break;
                }
            case 2:
                {
                    _platformaShoot.CancelShoot();
                    break;
                }
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformaShoot _platforma))
        {
            _platformaShoot = _platforma;
            BonusActivate();
        }
        Destroy(gameObject,3f);
    }

    



}
