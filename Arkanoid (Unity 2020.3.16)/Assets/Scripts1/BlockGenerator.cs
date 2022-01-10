using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Linq;
using System.Globalization;
public class BlockGenerator
{
   public void Generate(GameLevel gameLevel,Transform parent) 
    { 
        for(int i = 0; i < gameLevel._listBlocks.Count; i++) 
        {
            GameObject game;
#if UNITY_EDITOR
            //game = PrefabUtility.InstantiatePrefab(gameLevel._listBlocks[i]._block.prefab, parent)as GameObject;
          //  game = PrefabUtility.InstantiatePrefab(gameLevel._listBlocks[i]._block.prefab, parent) as GameObject;
          //  game.transform.position = gameLevel._listBlocks[i]._position;
#endif
        }
    }

    public void GenerateXElement(XElement root,Transform parent,GameLevel gameLevel) 
    {
        int i = 0;
        foreach (XElement instance in root.Elements("instance")) 
        {
            Vector3 position = Vector3.zero;
            position.x = float.Parse(instance.Attribute("x").Value,CultureInfo.InvariantCulture);
            position.y= float.Parse(instance.Attribute("y").Value, CultureInfo.InvariantCulture);
            GameObject game;
              game = PrefabUtility.InstantiatePrefab(gameLevel._listBlocks[i]._block.prefab, parent) as GameObject;
              game.transform.position = new Vector2(position.x,position.y);
            i++;
            //Debug.Log(position.x);


        }
    }
}
