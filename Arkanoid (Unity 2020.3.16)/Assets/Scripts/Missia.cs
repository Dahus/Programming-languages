using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Missia : MonoBehaviour
{
    const int maxLevel = 30;
    [Range(1, maxLevel)]
    [SerializeField] private int level = 1;
    private float ballVelocityMult = 0.02f;
    [SerializeField] private Sprite[] spriteBackground;
    [SerializeField] private Text textLevel;


    [SerializeField] private SpriteRenderer background;
    public GameObject bluePrefab;
    public GameObject redPrefab;
    public GameObject greenPrefab;
    public GameObject yellowPrefab;
    public GameObject yellowMovePrefab;
    public Ball ballPrefab;
    [SerializeField] private GameObject rocket;

    [SerializeField] private CreaterBonus _creator;
    [SerializeField] GameObject placeCreateBall;
    [SerializeField] AudioSource audioSource;
    [SerializeField] CountBlock countBlock;
    [SerializeField] private int reserveBall;

    private static Collider2D[] colliders = new Collider2D[50];
    private static ContactFilter2D contactFilter = new ContactFilter2D();

    Camera camera;

    void Start()
    {
        level = PlayerPrefs.GetInt("NumberLevel");
        if(level == 0) 
        {
            level = 1;
        }
        //level++;
       // GetComponent<WinOrDefeat>().SetLevel(level);
        camera = Camera.main;
        Cursor.visible = false;
        StartLevel();
        Time.timeScale=1;
    }

    public void SavePoints() 
    {
     //  PlayerPrefs.SetInt("Points", countBlock.GetPoints());
    }
    void CreateBlocks(GameObject prefab, float xMax, float yMax, int count, int maxCount, bool plusCountBlock)
    {


        if (count > maxCount)
        {
            count = maxCount;

        }
        if (plusCountBlock == true)
           // countBlock.InitializeCountBlock(count);
        for (int i = 0; i < count; i++)
        {
            for (int k = 0; k < 20; k++)
            {
                GameObject obj = Instantiate(prefab, new Vector2((Random.value * 2 - 1) * xMax, Random.value * yMax), Quaternion.identity);
                if (plusCountBlock == true)
                   //obj.GetComponent<BlockScripts>().AddEvent(countBlock);
                obj.GetComponent<BlockScripts>().SetCreaterBonus(_creator);
                if (obj.GetComponent<Collider2D>().OverlapCollider(contactFilter.NoFilter(), colliders) == 0)
                    break;
                Destroy(obj);

            }
        }
    }

    void CreateBalls()
    {
        int count = 2;
       // countBlock.InitializeCountBall(count);
        for (int i = 0; i < count; i++)
        {
            Ball obj = Instantiate(ballPrefab, placeCreateBall.transform.position, Quaternion.identity);
            // var ball = obj.GetComponent<BallScripts>();
           // obj.ballInitialForce += new Vector2(10 * i, 0);
           // obj.ballInitialForce *= 1 + level * ballVelocityMult;
           // obj.SetPlay(rocket);
           // obj.SetAudioSource(audioSource);
           // obj.AddEvent(countBlock);
            //countBlock.AddBallInList(obj);

        }
    }

    /*public void CreateBalls(int count) 
    {
    //    countBlock.InitializeCountBall(count);
        for (int i = 0; i < count; i++)
        {
      //      BallScripts obj = Instantiate(ballPrefab, placeCreateBall.transform.position, Quaternion.identity);
            // var ball = obj.GetComponent<BallScripts>();
            obj.ballInitialForce += new Vector2(10 * i, 0);
            obj.ballInitialForce *= 1 + level * ballVelocityMult;
            obj.SetPlay(rocket);
            obj.SetAudioSource(audioSource);
            obj.AddEvent(countBlock);
            countBlock.AddBallInList(obj);
        }
    }*/

    void StartLevel()
    {
        var yMax = camera.orthographicSize * 0.8f;
        var xMax = camera.orthographicSize * camera.aspect * 0.85f;
        background.sprite = spriteBackground[level-1];
        textLevel.text = "Level: " + level;
        CreateBlocks(bluePrefab, xMax, yMax, level, 8, false);
        CreateBlocks(redPrefab, xMax, yMax, 1 + level, 10, true);
        CreateBlocks(greenPrefab, xMax, yMax, 1 + level, 12, true);
        CreateBlocks(yellowPrefab, xMax, yMax, 2 + level, 15, true);
        CreateBlocks(yellowMovePrefab, xMax, yMax, 1 + level, 7, true);
        CreateBalls();
        Time.timeScale = 1;
    }

    public void NewGame() 
    {
       PlayerPrefs.SetInt("Points",0);
       PlayerPrefs.SetInt("NumberLevel",0);
      // GetComponent<WinOrDefeat>().SetLevel(level);
      
        StartLevel();
    }
}
