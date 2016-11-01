using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Stadium")]
public class LevelContainer {

    [XmlArray("Levels")]
    [XmlArrayItem("Level")]
    public List<Level> levels = new List<Level>();

    public static LevelContainer Load()
    {
        string path = "1-tutorial-stadium-levels";
        return Load(path);
    }

    public static LevelContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(LevelContainer));

        StringReader reader = new StringReader(_xml.text);

        LevelContainer levels = serializer.Deserialize(reader) as LevelContainer;

        reader.Close();

        parseXmlMapElements(levels.levels);

        return levels;
    }
    

    public static void parseXmlMapElements(List<Level> levels)
    {
        foreach(Level level in levels)
        {
            level.parseXmlMapElements();
        }
    }
}
