using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{

    public static event Action<float> OnMove;
    private Vector2 _startPosition = Vector2.zero;
    private float _direction=0f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxis("Horizontal"));
#endif
#if UNITY_ANDROID
  GetTouchInput();
#endif

    }

    private void GetTouchInput() 
    {
        if (Input.touchCount > 0) 
        {
            Touch touch =  Input.GetTouch(0);
            switch (touch.phase) 
            {
                case TouchPhase.Moved:
                    _direction = touch.position.x > _startPosition.x ? 1f : -1f;
                   // Debug.Log(_direction);
                    break;
                default:
                    _startPosition = touch.position;
                    _direction = 0f;
                    break;
            }
        }
        OnMove?.Invoke(_direction);
    }
}
