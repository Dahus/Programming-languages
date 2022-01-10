using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BlockForCombo : BlockScripts
{
    // Start is called before the first frame update
    //[SerializeField] private UnityEvent _renameEventX = new UnityEvent();
    //[SerializeField] private UnityEvent _renameEventO = new UnityEvent();
    [SerializeField] private ComboBlock _combo; 
    [SerializeField] private bool _isNameX = false;
    public override void Start()
    {
        textBox.text = "O";
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            Rename();
        }
        if (collision.gameObject.GetComponent<Patron>())
        {
            Rename();
            collision.gameObject.GetComponent<Patron>().DestroyObject();
        }
        
    }

    public void Rename() 
    {
        _isNameX = !_isNameX;
        if (_isNameX == true) 
        {
            
            textBox.text = "X";
            _combo.XBlockState(1);
        }
        else if (_isNameX == false) 
        {
            textBox.text = "O";
            _combo.XBlockState(-1);
        }
        
    }

    public void DestroyBlokcs()
    {
        _updatePoints.Invoke(points);
        Destroy(gameObject);
    }
}
