using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "GameData/Create/GameLevel")]
public class GameLevel : ScriptableObject
{
    public List<BlockObject> _listBlocks = new List<BlockObject>();
    public Level _level; 

    public void InitLevel() 
    {
       for(int i = 0; i < _listBlocks.Count; i++) 
        {
            _level.AddBlock(_listBlocks[i]._position,_listBlocks[i]._block);
        }
    }
}

[System.Serializable]
public class BlockObject
{
    public Vector3 _position;
    public BlockData _block;
   // public string strBlock;
}