﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Stadium
{

    [XmlAttribute("name")]
    public string name;
    
    [XmlElement("XmlLevelsPath")]
    public string xmlLevelsPath;

    [XmlElement("MinStarsToUnlock")]
    public int minStarsToUnlock;

    public List<Level> levels;


}