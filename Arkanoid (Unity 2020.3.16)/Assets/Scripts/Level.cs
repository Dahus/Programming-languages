using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelInMissia", menuName = "GameData/Create/Missia")]
[System.Serializable]
public class Level : ScriptableObject
{
    public List<BlockObjectGame> _listBlocks = new List<BlockObjectGame>();
    public void AddBlock(Vector3 pos,BlockData block) 
    {
        BlockObjectGame _BOG = new BlockObjectGame();
        _BOG._position = pos;
        _BOG._block = block;
        _listBlocks.Add(_BOG);
    }
}
[System.Serializable]
public class BlockObjectGame
{
    public Vector3 _position;
    public BlockData _block;
}