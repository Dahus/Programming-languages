using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSticky : MonoBehaviour
{
    [SerializeField] private Ball _ballSticky;
    [SerializeField] private bool _isSticky;

    public void SetSticky(bool sticky) 
    {
        _isSticky = sticky;
    }

    public void NullBall() 
    {
        _ballSticky = null;
    }

  /*  public void Sticket(Ball ball) 
    {
        _ballSticky = ball;
        _ballSticky.transform.parent = gameObject.transform;
    }
  */
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if(_ballSticky==null&& _isSticky == true&& collision.gameObject.TryGetComponent(out Ball ball) )
        {
           
            _ballSticky = ball;
            _ballSticky.transform.parent = gameObject.transform;
            _ballSticky.Sticky(gameObject.GetComponent<PlatformSticky>());
        }
    }
}
