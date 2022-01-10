using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    [SerializeField] private CountBall _countBall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.TryGetComponent(out Ball ball)) 
        {
            ball.DestroyBall();
            _countBall.DestroyBall();
        }
    }
}
