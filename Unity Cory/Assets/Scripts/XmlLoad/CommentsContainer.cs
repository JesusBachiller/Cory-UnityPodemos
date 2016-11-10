using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Level")]
public class CommentsContainer
{

    [XmlArray("Comments")]
    [XmlArrayItem("Comment")]
    public List<Comment> comments = new List<Comment>();

    public static CommentsContainer Load()
    {
        string path = "Comments/comments-tutorial-0";
        return Load(path);
    }

    public static CommentsContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(CommentsContainer));

        StringReader reader = new StringReader(_xml.text);

        CommentsContainer cc = serializer.Deserialize(reader) as CommentsContainer;

        reader.Close();

        return cc;
    }
}
