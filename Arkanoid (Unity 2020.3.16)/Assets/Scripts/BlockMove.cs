using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : BlockScripts
{
    [SerializeField]private int direction = -1;
    [SerializeField] private float speed = 1;
      
    
   public void MoveBlock() 
   {
        transform.Translate(Vector2.left * direction*speed * Time.fixedDeltaTime);
   }

    private void FixedUpdate()
    {
        MoveBlock();
    }
   

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.GetComponent<BlockScripts>() || collision.gameObject.GetComponent<Wall>()) 
        {
            direction = direction * (-1);
        }

    /*    if (collision.gameObject.GetComponent<BallScripts>())
        {
            hitDestroy = hitDestroy - collision.gameObject.GetComponent<BallScripts>().GetPower();
        }
        if (hitDestroy <= 0 && isSent == false)
        {
            //Debug.Log(gameObject.name);
            isSent = true;
            _updateCountBlock.Invoke();
            _updatePoints.Invoke(points);
            Destroy(gameObject);
        }
    */
    }
}
