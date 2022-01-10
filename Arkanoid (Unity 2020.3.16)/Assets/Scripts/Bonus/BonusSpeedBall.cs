using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpeedBall : Bonus
{
    [SerializeField] private int boostForBall;
    public override void BonusActivate()
    {
        base.BonusActivate();
        _countball.SpeedBall(boostForBall);
    }
}
