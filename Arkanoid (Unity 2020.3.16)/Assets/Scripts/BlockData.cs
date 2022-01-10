using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BlockData",menuName ="GameData/Create/BlockData")]
public class BlockData :ScriptableObject
{
    public GameObject prefab;
    public List<Sprite> sprites;
    public Color baseColor;
    public int Score;
}
