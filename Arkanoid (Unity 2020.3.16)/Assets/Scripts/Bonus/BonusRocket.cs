using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRocket : Bonus
{

    [SerializeField] private bool _isScale; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void BonusActivate()
    {
        base.BonusActivate();
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformaSizer platforma))
        {
            platforma.Scaling(_isScale);
            Debug.Log("Бонус");
            BonusActivate();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
