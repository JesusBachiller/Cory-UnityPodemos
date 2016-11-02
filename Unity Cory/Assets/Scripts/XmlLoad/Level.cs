using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Level {

    [XmlAttribute("index")]
    public int index;

    [XmlAttribute("name")]
    public string name;

    [XmlElement("MapElements")]
    public string xmlMapElements;

    [XmlElement("AvailableTools")]
    public string xmlAvailableTools;

    [XmlElement("MinStarsToUnlock")]
    public int minStarsToUnlock;

    [XmlElement("PreviewImagePath")]
    public string previewImagePath;
    
    public List<List<char>> mapElements;
    public int[] availableTools;
    public LevelSavedData levelSavedData;

    public void parseXmlMapElements()
    {
        mapElements = new List<List<char>>();
        List<char> actualRow = new List<char>();
        foreach (char c in xmlMapElements)
        {
            if (c != '-') {
                if ((char.IsDigit(c) || char.IsLetter(c)) && !char.IsWhiteSpace(c))
                {
                    actualRow.Add(c);
                }
            } else
            {
                mapElements.Add(actualRow); // Copies the reference -and not the complete content- of the list actualRow.
                actualRow = new List<char>(); // That's why we create a new List here.
            }
        }
        mapElements.Add(actualRow); // Add the final row that doesn't end with a '-'
    }
}
