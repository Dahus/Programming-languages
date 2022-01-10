using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Xml.Linq;
using System.Globalization;
public class CountBlock : MonoBehaviour
{
   //public static CountBlock instance { get; private set; }

    [SerializeField] private int _blocks;
    [SerializeField] private int _count;
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;
    [SerializeField] private PointsCounter _pointsCounter;
    [SerializeField] private BlockScripts[] _arrayBlock;
    [SerializeField] private Createrlevel _createrlevel;
    [SerializeField] private CreaterBonus _bonusCreator;
    //[SerializeField] private Missia _missia;

    private Camera camera;
    private float xMax, yMax;


   [SerializeField] UnityEvent _eventEndRound = new UnityEvent();
    private static ContactFilter2D contactFilter = new ContactFilter2D();
    private static Collider2D[] colliders = new Collider2D[50];

    public void RandomCount() 
    {
        _count = Random.Range(_minCount, _maxCount);
    }

    private void Start()
    {
         camera = Camera.main;
         yMax = camera.orthographicSize * 0.8f;
         xMax = camera.orthographicSize * camera.aspect * 0.85f;
        // RandomCount();
        // CreateBlocks();
    }

    

    public void DestroyAllRound() 
    {
        _eventEndRound.Invoke();
    }



  public void CreateBlocks()
    {
        _blocks = _count;
        for (int i = 0; i < _count; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                int randBlock = Random.Range(0, _arrayBlock.Length);
                BlockScripts obj = Instantiate(_arrayBlock[randBlock], new Vector2((Random.value * 2 - 1)*xMax, Random.value*yMax), Quaternion.identity);
                obj.SetCountBlock(this);
                obj.SetCreaterBonus(_bonusCreator);
                obj.AddEvent();
                //_eventEndRound.AddListener(obj.DestoryBlockInEndRound);
                if (obj.GetComponent<Collider2D>().OverlapCollider(contactFilter.NoFilter(), colliders) == 0)
                    break;
                Destroy(obj.gameObject);
                
            }
        }
    }



    public void CreateBLockMissia(GameLevel missia, XElement root) 
    {
        /*_blocks = missia._listBlocks.Count;
        for( int i = 0; i < _blocks; i++) 
        {
            GameObject obj = Instantiate(missia._listBlocks[i]._block.prefab, missia._listBlocks[i]._position, Quaternion.identity);
            BlockScripts blockScripts = obj.GetComponent<BlockScripts>();
            blockScripts.SetCreaterBonus(_bonusCreator);
            blockScripts.SetCountBlock(this);
            blockScripts.AddEvent();
        }*/
        int i = 0;
        foreach (XElement instance in root.Elements("instance"))
        {
            
            Vector3 position = Vector3.zero;
            position.x = float.Parse(instance.Attribute("x").Value, CultureInfo.InvariantCulture);
            position.y = float.Parse(instance.Attribute("y").Value, CultureInfo.InvariantCulture);
            GameObject obj = Instantiate(missia._listBlocks[i]._block.prefab, new Vector2(position.x,position.y), Quaternion.identity);
            BlockScripts blockScripts = obj.GetComponent<BlockScripts>();
            blockScripts.SetCreaterBonus(_bonusCreator);
            blockScripts.SetCountBlock(this);
            blockScripts.AddEvent();
            i++;
            _blocks++;
            //Debug.Log(position.x);


        }
    }





    //[SerializeField] private List<Ball> _balls=new List<Ball>();


    

    public void DestroyBlock(int point) 
    {
        _blocks--;
        _pointsCounter.IncreasePoints(point);
       // textCountBlock.text = "Count Block: " + _blocks;
        if (_blocks <= 0) 
        {
            _createrlevel.LevelUP();
            _createrlevel.CreateLevel();

            //Debug.Log("победа");
           // winOrDefeat.Win();
        }
    }


   
}
