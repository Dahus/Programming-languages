using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Ball : MonoBehaviour
{
    [SerializeField]private Rigidbody2D _rigidbody2D;
    private bool _isActiv = false;
    [SerializeField] private  float _force = 300f;
    private float _lastPositionX;

    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public bool _isClone = false;
    public bool _isSticky = false;
    public Vector2 ballInitialForce;
    private UnityEvent _eventCreateNewBall = new UnityEvent();

    private PlatformSticky _platformaSticky;


    public void SetColor(Color color) 
    {
        _spriteRenderer.color = color;
    }

    public void SetDamage(int damage) 
    {
        _damage = damage;
    }
   

    private void Start()
    {
        if (_isClone == false)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
           
        }
        //_damage = GetComponent<BallCharacter>().GetDamage();
    }

   public void DestroyinEndRound() 
   {
        Destroy(gameObject);  
   }

    public void SetupEventCreateNewBall(UnityAction action) 
    {
        _eventCreateNewBall.AddListener(action);
    } 


    public void Sticky(PlatformSticky platforma) 
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _rigidbody2D.velocity = _rigidbody2D.velocity * 0;
        _isSticky = true;
        _platformaSticky = platforma;
    }

    public int GetPower() 
    {
        return _damage;
    }

    public void DestroyBall() 
    {
        //_eventCreateNewBall.Invoke();
        Destroy(gameObject);
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)&&_isActiv==false)
        {
            BallActivate(); 
        }
        if (_isSticky == true && Input.GetKeyDown(KeyCode.Space)) 
        {
            StickyEnd();
        }
#endif
       /* if (Input.GetKeyDown(KeyCode.Z)) 
        {
            ChangeSpeed(-2);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeSpeed(2);
        }*/
#if UNITY_ANDROID
        if (Input.touchCount > 0 && _isActiv==false) 
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount > 1) 
            {
                BallActivate();
            }
        }
#endif
    }

    public void StickyEnd() 
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.AddForce(Vector2.up * _force);
       
        transform.SetParent(null);
        _platformaSticky.NullBall();
        _isSticky = false;
    }

    public void BallActivate() 
    {
        _isClone = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        // _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _isActiv = true;
        _lastPositionX = transform.position.x;
        transform.SetParent(null);
        //_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.AddForce(Vector2.up*_force);
        //Vector2 _newVectorForce = new Vector2(Random.Range(70, 100), Random.Range(100, 300));
        //_rigidbody2D.AddForce(_newVectorForce * _force);
        
    }

    private void FixedUpdate()
    { 
        _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _speed;
       // Debug.Log(_rigidbody2D.velocity.sqrMagnitude);
         

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float ballPositionX = transform.position.x;

        if(collision.gameObject.TryGetComponent(out PlatformMove platform)) 
        {
            if (ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1)
            {
                float collisionPointX = collision.contacts[0].point.x;
                _rigidbody2D.velocity = Vector2.one* _speed;
                
                float playerCenterPosition = platform.transform.position.x;
                float difference=playerCenterPosition - collisionPointX;
                float direction = collisionPointX < playerCenterPosition ? -1 : 1;
                _rigidbody2D.AddForce(new Vector2(direction * Mathf.Abs(difference * (_force/2)), _force));
            }
        }
        _lastPositionX = ballPositionX;

        if (collision.gameObject.TryGetComponent(out Block block))
        {
            //Destroy(block.gameObject);
            block.Damage(_damage);
        }
    }

    public void ChangeSpeed(int d) 
    {
        _speed =_speed+d;
    }

    public void CreateCopyBall(CountBall countBall) 
    { 
        Ball ball = Instantiate(gameObject.GetComponent<Ball>(), gameObject.transform.position,Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 _newVectorForce = new Vector2(Random.Range(70, 100), Random.Range(100, 300));
        //Vector2 _newVectorForce = new Vector2(ballInitialForce.x- Random.Range(0,20),ballInitialForce.y- Random.Range(0,20));
        ball.GetComponent<Rigidbody2D>().AddForce(_newVectorForce);
        countBall.AddBalls(ball);
        //AddEvent(CountBlock.instance);
        //Vector2 difference = new Vector2(ballInitialForce.x - _newVectorForce.x, ballInitialForce.y - _newVectorForce.y);
        //StartCoroutine("Pausa");
        //ball.GetComponent<Rigidbody2D>().AddForce(difference);
        //CountBlock.instance.AddBallInList(ball);
        //CountBlock.instance.IncreaseBall();
    }
}

