using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;
public class Createrlevel : MonoBehaviour
{
    [SerializeField] private CountBlock _countBlock;
    [SerializeField] private int[] _massivReadyLevels;
    [SerializeField] private Sprite[] _background;
    [SerializeField] private GameLevel[] _missia;
    [SerializeField] private string[] _nameMissia;
    [SerializeField] private int _numberlevel;
    [SerializeField] private int chooseLevel;
    [SerializeField] private UIUpdater _uiUpdater;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private SpriteRenderer _backgroundInGame;
    [SerializeField] private bool IsLoadChooseLevel;
 
    public void CreateLevel() 
    {
        if (IsLoadChooseLevel == true) 
        {
            _numberlevel = chooseLevel;
        }
        if (_missia.Length>_numberlevel) 
        {
            Debug.Log("уровень создан");
            _countBlock.CreateBLockMissia(_missia[_numberlevel],LoadBlock(_nameMissia[_numberlevel]));
            _backgroundInGame.sprite = _background[_numberlevel];
            Debug.Log(_numberlevel);
        }
        else 
        {
            _countBlock.RandomCount();
            _countBlock.CreateBlocks();
            _backgroundInGame.sprite = _background[_numberlevel];

        }
    }


    public XElement LoadBlock(string str)
    {
        XElement root = null;
        string path = "Assets/xmltest/" + str + ".xml";
        if (File.Exists(path))
        {
            root = XDocument.Parse(File.ReadAllText(path)).Element("root");
        }

        Debug.Log("root прочитан" + root);
        return root;
    }
    public void LevelUP() 
    {
        _numberlevel++;
        _uiUpdater.UpdateLevel(_numberlevel);
        _saveSystem.Save();
    }

    public int GetLevel() 
    {
        return _numberlevel;
    }


    public void Start()
    {
        CreateLevel();
    }

    public void SetLevel(int level) 
    {
        _numberlevel = level;
        _uiUpdater.UpdateLevel(_numberlevel);
    }
} 
