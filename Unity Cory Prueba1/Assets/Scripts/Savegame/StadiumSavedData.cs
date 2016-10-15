using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StadiumSavedData
{
    public List<LevelSavedData> levelSavedData;


    public StadiumSavedData()
    {
        levelSavedData = new List<LevelSavedData>();
    }
}
