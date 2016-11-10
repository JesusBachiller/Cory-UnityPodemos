using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("WorldMap")]
public class StadiumContainer
{

    [XmlArray("Stadiums")]
    [XmlArrayItem("Stadium")]
    public List<Stadium> stadiums = new List<Stadium>();

    public static StadiumContainer Load()
    {
        string path = "stadiums";
        return Load(path);
    }

    public static StadiumContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(StadiumContainer));

        StringReader reader = new StringReader(_xml.text);

        StadiumContainer sc = serializer.Deserialize(reader) as StadiumContainer;

        reader.Close();

        return sc;
    }
    
    public void LoadLevelsOfStadiums()
    {
        foreach(Stadium stadium in stadiums)
        {
            stadium.levels = LevelContainer.Load(stadium.xmlLevelsPath).levels;
        }
    }
}
