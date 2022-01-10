using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class XMLManager : MonoBehaviour
{
    public static XMLManager ins;

    private void Awake()
    {
        ins = this;
    }
}


[System.Serializable]
public class ItemEntry 
{
    public string blocktype;
    public Vector3 vector;
}
