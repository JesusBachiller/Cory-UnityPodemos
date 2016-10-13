using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Level {

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

    [XmlElement("MaxScore")]
    public int maxScore;

    [XmlElement("FastestTime")]
    public int fastestTime;

    [XmlElement("SceneName")]
    public string sceneName;

    public List<List<int>> mapElements;
    public int[] availableTools;

    public void parseXmlMapElements()
    {
        mapElements = new List<List<int>>();
        List<int> actualRow = new List<int>();
        foreach (char c in xmlMapElements)
        {
            if (c != '-') {
                if (char.IsDigit(c))
                {
                    actualRow.Add((int)char.GetNumericValue(c));
                }
            } else
            {
                mapElements.Add(actualRow); // Copies the reference -and not the complete content- of the list actualRow.
                actualRow = new List<int>(); // That's why we create a new List here.
            }
        }
        mapElements.Add(actualRow); // Add the final row that doesn't end with a '-'
    }
}
