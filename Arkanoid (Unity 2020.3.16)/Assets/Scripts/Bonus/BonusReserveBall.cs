using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusReserveBall : Bonus
{
    // Start is called before the first frame update
    
    enum IncriaseBall
    {
        Reserve1=0,
        ReserveAndGame2=1,
        ReserveAndGame10=2
    };

    [SerializeField] private IncriaseBall _inc;
    public override void BonusActivate()
    {
        base.BonusActivate();
        int choose = (int)_inc;
        switch (choose)
        {
            case 0: 
                {
                    _countball.CreateBall(1);
                    break;
                }
            case 1: 
                {
                    _countball.CreateBall(2);
                    break;
                }
            case 2: 
                {
                    _countball.CreateBall(10);
                    break;
                }
        }     
    }

    

}
