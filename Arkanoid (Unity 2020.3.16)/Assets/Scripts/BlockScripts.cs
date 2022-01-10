using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class BlockScripts : MonoBehaviour
{
    [SerializeField] protected Text textBox;
    [SerializeField] protected int hitDestroy;
    [SerializeField] protected int points;
    [SerializeField] protected bool isSent = false;
    [SerializeField] protected CreaterBonus createrBonus;
    [SerializeField] private CountBlock _countBlock;
    public BlockData _blockData;


   public BlockType.BlockTypeEnum _blockType;
    //protected UnityEvent _updateCountBlock=new UnityEvent();
    protected UnityEvent<int> _updatePoints = new UnityEvent<int>();
    // Start is called before the first frame update
  public virtual void  Start()
    {

        if (textBox != null)
        {
            textBox.text = hitDestroy.ToString();
        }
    }


   public void DebugBlockData() 
    {
        Debug.Log(_blockData.name);
    }

    public void SetCountBlock(CountBlock countBlock)
    {
        _countBlock = countBlock;
    }

    public void SetCreaterBonus(CreaterBonus cr) 
    {
        createrBonus = cr;
    }

    public void AddEvent() 
    {

       //_updateCountBlock.AddListener(_countBlock.DestroyBlock);
        _updatePoints.AddListener(_countBlock.DestroyBlock);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    


    public virtual void  OnCollisionEnter2D(Collision2D collision)
    {

        //Debug.Log("оригинал");
        if (collision.gameObject.GetComponent<Ball>())
        {
            hitDestroy = hitDestroy - collision.gameObject.GetComponent<Ball>().GetPower();
        }
        if (collision.gameObject.GetComponent<Patron>()) 
        {
            hitDestroy = hitDestroy - collision.gameObject.GetComponent<Patron>().GetPower();
            collision.gameObject.GetComponent<Patron>().DestroyObject();
        }
        if (hitDestroy <= 0&& isSent==false) 
        {
            //Debug.Log(gameObject.name);
            isSent = true;
            CreateBonus();
            //Transform newPos = gameObject.transform;
            //createrBonus.CheckChanceBonus(newPos);

           // bool flag = createrBonus.CheckChanceBonus();
           // if (flag == true) 
           // {
           //     CreateBonus();
           // }
           // _updateCountBlock.Invoke();
            _updatePoints.Invoke(points);
            Destroy(gameObject);        
        }
        else if (textBox != null) 
        {
            textBox.text = hitDestroy.ToString();
        }
    }

  
    public void CreateBonus() 
    {
        createrBonus.CreateBonus(transform);
    }

}
