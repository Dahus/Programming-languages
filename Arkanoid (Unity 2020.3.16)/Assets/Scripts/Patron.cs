using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
   [SerializeField]private Rigidbody2D _rb;
   [SerializeField] private int _damage;
    [SerializeField] private float _timeDestroy;
   

    public void Fly()
    {
        _rb.AddForce(Vector2.up * 1000);
        Debug.Log("Fly");
    }

    public void DestroyObject() 
    {
        Destroy(gameObject);
    }

    public void CallDestroy() 
    {
        StartCoroutine(Destroyer());
    }

    public int GetPower() 
    {
        return _damage;
    }

    IEnumerator Destroyer() 
    {
        yield return new WaitForSeconds(_timeDestroy);
        DestroyObject();
    }
}
