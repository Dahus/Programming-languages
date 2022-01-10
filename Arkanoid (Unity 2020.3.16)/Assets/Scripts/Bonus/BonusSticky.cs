using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSticky : Bonus
{
    [SerializeField] private bool _isSticky;

    public override void BonusActivate()
    {
        base.BonusActivate();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSticky platforma))
        {
            platforma.SetSticky(_isSticky);
            BonusActivate();
            Destroy(gameObject);
        }
    }
}
