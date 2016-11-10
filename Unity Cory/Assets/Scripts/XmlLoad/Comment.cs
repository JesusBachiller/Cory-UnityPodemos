using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Comment  {

    [XmlElement("Text")]
    public string text;
    
    [XmlElement("ImagePath")]
    public string imagePath;
}
