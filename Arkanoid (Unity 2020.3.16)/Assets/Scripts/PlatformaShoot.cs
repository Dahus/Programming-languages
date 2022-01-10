using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaShoot : MonoBehaviour
{
    [SerializeField] private GameObject _pricel;
    [SerializeField] private Patron _patron;
    [SerializeField] private GameObject _superPricel;
    [SerializeField] private Patron _superPatron;
    [SerializeField] private bool _isReload=false;
    [SerializeField] private Patron _choosePatron;
    [SerializeField] private GameObject _choosePricel; 
    public void BonusShoot() 
    {
        _pricel.SetActive(true);
        _superPricel.SetActive(false);
        _choosePatron = _patron;
        _isReload = true;
        _choosePricel= _pricel;
    }

    public void BonusSuperShoot() 
    {
        _superPricel.SetActive(true);
        _pricel.SetActive(false);
        _choosePatron = _superPatron;
        _isReload = true;
        _choosePricel = _superPricel;
    }

    public void CancelShoot() 
    {
        _superPricel.SetActive(false);
        _pricel.SetActive(false);
        _isReload = false;
    }



    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0) && _isReload == true) 
        {
            Patron patron = Instantiate(_choosePatron, new Vector2(_choosePricel.transform.position.x, _choosePricel.transform.position.y+2f), Quaternion.identity);
            patron.Fly();
            patron.CallDestroy();
            _isReload = false;
            StartCoroutine(Reloader());
        }/*
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            BonusShoot();
        }
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            BonusSuperShoot();
        }
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            CancelShoot();
        }*/
    }

    IEnumerator Reloader()
    {  
            yield return new WaitForSeconds(3f);
            _isReload = true;
    }


}
