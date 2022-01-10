using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCharacter : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;


    public int GetDamage() 
    {
        return _damage;
    }

    public int GetSpeed()
    {
        return _speed;
    }



}
