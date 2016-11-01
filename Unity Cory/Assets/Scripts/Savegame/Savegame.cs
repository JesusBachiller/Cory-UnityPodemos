using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Savegame {

    public static Savegame current;
    public List<StadiumSavedData> stadiumsSavedData = new List<StadiumSavedData>();
    public int starsAchieved;
    public int timesDied;
    public int vecesClickadasBotonPlay;

    /*public Savegame()
    {
        starsAchieved = 0;
        timesDied = 0;
        vecesClickadasBotonPlay = 0;
        //stadiumsSavedData = new List<StadiumSavedData>();
    }*/
}
