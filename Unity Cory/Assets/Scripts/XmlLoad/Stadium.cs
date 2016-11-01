using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Stadium
{

    [XmlAttribute("index")]
    public int index;

    [XmlAttribute("name")]
    public string name;
    
    [XmlElement("XmlLevelsPath")]
    public string xmlLevelsPath;

    [XmlElement("MinStarsToUnlock")]
    public int minStarsToUnlock;

    [XmlElement("SceneName")]
    public string sceneName;

    public List<Level> levels;


}
