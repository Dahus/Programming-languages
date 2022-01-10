using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
public class XmlDataOnobject : MonoBehaviour
{
    
    public XElement GetElement() 
    {
        XAttribute x = new XAttribute("x", transform.position.x);
        XAttribute y = new XAttribute("y", transform.position.y);
        XAttribute typeBlock = new XAttribute("typeBlock", GetComponent<BlockScripts>()._blockType);
        XElement element = new XElement("instance", x, y, typeBlock);
        return element;
    }
}