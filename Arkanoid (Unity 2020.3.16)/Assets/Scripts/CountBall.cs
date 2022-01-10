using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CountBall : MonoBehaviour
{

    [SerializeField] private Ball _ball;
    [SerializeField] private int _countBall = 0;
    [SerializeField] private PlatformMove _platforma;
    [SerializeField] private CountLive _countLive;

    [SerializeField] private List<Ball> _balls = new List<Ball>();

    [SerializeField] private Vector2 ballInitialForce;
    UnityEvent _eventEndRound = new UnityEvent();

    private void Start()
    {
        Ball ball = Instantiate(_ball, new Vector3(_platforma.transform.position.x, _platforma.transform.position.y + 3f), Quaternion.identity);
        ball.transform.SetParent(_platforma.transform);
        _balls.Add(ball);
        _countBall++;
    }

    
    public  void CreateBall() 
    {
      Ball ball=Instantiate(_ball, new Vector3(_platforma.transform.position.x, _platforma.transform.position.y + 3f), Quaternion.identity);
        ball.SetupEventCreateNewBall(DestroyBall);
        _balls.Add(ball);
        _eventEndRound.AddListener(ball.DestroyinEndRound);
        ball.transform.SetParent(_platforma.transform);
        _countBall++;
    }

    public void CreateBall(int d)
    {
        for (int i = 0; i < d; i++)
        {
            StartCoroutine(Timers());
            Ball ball = Instantiate(_ball, new Vector3(_platforma.transform.position.x+Random.Range(0,5f), _platforma.transform.position.y + 3f), Quaternion.identity);
            ball.SetupEventCreateNewBall(DestroyBall);
            //ball.GetComponent<Rigidbody2D>().isKinematic = false;
            ball.BallActivate();
            _balls.Add(ball);
            _eventEndRound.AddListener(ball.DestroyinEndRound);
            //ball.transform.SetParent(_platforma.transform);
            //Vector2 _newVectorForce = new Vector2(ballInitialForce.x - Random.Range(0, 20), ballInitialForce.y - Random.Range(0, 20));
            //ball.GetComponent<Rigidbody2D>().AddForce(_newVectorForce);
            _countBall++;
        }
    }

    private void Update() 
    {
    
    }

    public void DestroyBall()
    {
        _countBall--;
        if (_countBall <= 0) 
        {
            _countBall = 0;
            _countLive.UpdateCountLive();
            
        }
    }

    public void DestroyAllRound() 
    {
        _eventEndRound.Invoke();
        _countBall = 0;
    }

    
    public void Fireball(int damage,Color color) 
    {
        for (int i = 0; i < _balls.Count; i++) 
        {
            _balls[i].SetColor(color);
            _balls[i].SetDamage(damage);
        }
    }

    public void SpeedBall(int d) 
    {
        for(int i = 0; i < _balls.Count; i++) 
        {
            if (_balls[i] != null)
            {
                _balls[i].ChangeSpeed(d);
            }
        }
    }

    public void CreateCopyBall(int copy) 
    {
        for (int i = 0; i < _balls.Count; i++)
        {
            if (_balls[i] != null)
            {
                _balls[i].CreateCopyBall(this);
            }
        }
    }

    public void AddBalls(Ball ball) 
    {
        _balls.Add(ball);
    }

   IEnumerator Timers() 
    {
        yield return new WaitForSeconds(1f);
    }


}
