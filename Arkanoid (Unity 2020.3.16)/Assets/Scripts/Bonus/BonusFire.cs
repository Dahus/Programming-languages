using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFire : Bonus
{
    [SerializeField] private int damage;
    [SerializeField] private Color color;
    void Start()
    {
        
    }

    public override void BonusActivate()
    {
        base.BonusActivate();
        _countball.Fireball(damage, color);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
