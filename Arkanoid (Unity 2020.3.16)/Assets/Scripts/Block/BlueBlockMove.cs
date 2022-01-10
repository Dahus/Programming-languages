using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockMove : MonoBehaviour
{

    [SerializeField] private float _distance;
    [SerializeField] private float _time;
    [SerializeField] private bool isRight=true;
    [SerializeField] private Vector2 _constPosition;
    // Start is called before the first frame update
    void Start()
    {
        _constPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BlockMoved();
    }

    public void BlockMoved() 
    {
        if (isRight == true)
        {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_constPosition.x + _distance, transform.position.y), _time * Time.fixedDeltaTime);
            Debug.Log(_constPosition.x);
            if (transform.position.x == _constPosition.x+_distance)
            {
                isRight = false;
            }
           
        }
        if (isRight == false) 
        { 
        transform.position= Vector2.MoveTowards(transform.position, new Vector2(_constPosition.x - _distance, transform.position.y), _time * Time.fixedDeltaTime);
            if (transform.position.x == _constPosition.x - _distance) 
            {
                Debug.Log(_constPosition.x);
                isRight = true;

            }

            }

        }
    }
