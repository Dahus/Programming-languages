using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Block : MonoBehaviour
{

    [SerializeField] private int _point;
    [SerializeField] private CountBlock _countBlock;
    [SerializeField] private int _hpBlock;
    public void SetCountBlock(CountBlock countBlock) 
    {
        _countBlock = countBlock;
    }

    public void Damage(int damage) 
    {
        _hpBlock = _hpBlock - damage;
        if (_hpBlock <= 0) 
        {
            _countBlock.DestroyBlock(_point);
            Destroy(gameObject);
        }

    }

    public void DestoryBlockInEndRound() 
    {
        Destroy(gameObject);
    }
    

    


    
}
