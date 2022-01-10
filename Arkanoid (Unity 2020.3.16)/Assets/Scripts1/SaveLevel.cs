using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;
public class SaveLevel : MonoBehaviour
{
    





    public List<BlockObject> GetBlocks(string str) 
    {
        List<BlockObject> _objects = new List<BlockObject>();
        GameObject[] allBlocks=GameObject.FindGameObjectsWithTag("Block");
        string path = "Assets/xmltest/" +str+".xml";
        XElement root = new XElement("root");
        foreach (var item in allBlocks)
        {
            BlockObject blockObject = new BlockObject();
            blockObject._position = item.gameObject.transform.position;
            item.gameObject.GetComponent<BlockScripts>().DebugBlockData();
            blockObject._block = item.gameObject.GetComponent<BlockScripts>()._blockData;
          root.Add(item.gameObject.GetComponent<XmlDataOnobject>().GetElement());
            _objects.Add(blockObject);
        }
        Debug.Log(root);
        XDocument saveDoc = new XDocument(root);
        File.WriteAllText(path, saveDoc.ToString());
        Debug.Log(path);
        return _objects;
    }

  public XElement LoadBlock(string str) 
    {
        XElement root = null;
        string path= "Assets/xmltest/" + str + ".xml";
        if (File.Exists(path)) 
        {
            root =XDocument.Parse(File.ReadAllText(path)).Element("root");
        }
        
        Debug.Log("root прочитан"+root);
        return root;
    }


}
