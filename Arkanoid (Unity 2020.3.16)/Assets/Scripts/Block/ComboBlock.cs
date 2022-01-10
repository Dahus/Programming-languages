using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboBlock : MonoBehaviour
{
    [SerializeField] private int _countBlock;
    [SerializeField] private int _xBlock=0;
    [SerializeField] private BlockForCombo[] block;
    // Start is called before the first frame update
    void Start()
    {
        _countBlock = block.Length;
    }

    
   

    public void XBlockState(int d) 
    {
        _xBlock=_xBlock+d;
      
        if(_xBlock==_countBlock)
        {
            for( int i = 0; i < _countBlock; i++) 
            {
                block[i].DestroyBlokcs();
            }
        }
    }

    
}
