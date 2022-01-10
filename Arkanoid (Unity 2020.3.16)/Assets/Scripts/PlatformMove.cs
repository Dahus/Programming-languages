using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _moveX = 0;
    [SerializeField] private float _borderPosition;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float positionX = _rigidbody2D.position.x + _moveX * _speed * Time.fixedDeltaTime;
        //Debug.Log(positionX);
        //positionX = Mathf.Clamp(positionX, -_borderPosition + (_spriteRenderer.size.x / 2), _borderPosition - (_spriteRenderer.size.x / 2));
        
        _rigidbody2D.MovePosition(new Vector2(positionX, _rigidbody2D.position.y));
        /*if (_borderPosition[0].transform.position.x+0.2f > gameObject.transform.position.x) 
        {
            _rigidbody2D.MovePosition(new Vector2(_borderPosition[0].transform.position.x+0.1f, _rigidbody2D.position.y));
        }
        if (_borderPosition[1].transform.position.x-0.2f < gameObject.transform.position.x)
        {
            _rigidbody2D.MovePosition(new Vector2(_borderPosition[1].transform.position.x - 0.1f, _rigidbody2D.position.y));
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.TryGetComponent(out Wall wall)) 
        { 
            
        }
    }


    private void OnEnable()
    {
        PlayerInput.OnMove += Move;
    }

    private void OnDisable()
    {
        PlayerInput.OnMove -= Move;
    }

    private void Move(float moveX)
    {
        _moveX = moveX;
    }
}
