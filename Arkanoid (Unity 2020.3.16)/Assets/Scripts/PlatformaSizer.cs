using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaSizer : MonoBehaviour
{
    // [SerializeField]private  int countDecrease = 0;
    [SerializeField] private int countSize=0;
    [SerializeField] private float constSize = 2;
    public void Scaling(bool isScale )
    {
        if (isScale==true&& countSize<2)//растет 
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.5f,transform.localScale.y+0.5f,transform.localScale.z);
            countSize++;
        }
        else if((isScale == false && countSize > -2))
        {
            transform.localScale = new Vector3(transform.localScale.x -0.5f, transform.localScale.y-0.5f, transform.localScale.z);
            countSize--;
        }
    }
}
