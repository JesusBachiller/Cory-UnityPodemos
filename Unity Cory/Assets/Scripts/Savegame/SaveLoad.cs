using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {

    public static Savegame savegame = new Savegame();
    //public static List<Savegame> savegames = new List<Savegame>(); // --> We can make a list if we want to allow various savegames
    
    //it's static so we can call it from anywhere
    public static void Save()
    {
        //SaveLoad.savegames.Add(Savegame.current);
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into //Debug.Log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.gd"); //you can call it anything you want
        bf.Serialize(file, SaveLoad.savegame);
        //bf.Serialize(file, SaveLoad.savegames);
        file.Close();
    }

    public static void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            //Debug.Log("Voy a crear savegame ya que no tengo");
            StadiumContainer sc = StadiumContainer.Load();
            foreach(Stadium s in sc.stadiums)
            {
                //Debug.Log("Guardo Estadio " + s.name);
                LevelContainer lc = LevelContainer.Load(s.xmlLevelsPath);
                StadiumSavedData ssd = new StadiumSavedData();
                foreach(Level l in lc.levels)
                {
                    //Debug.Log("Guardo Nivel "+l.name);
                    LevelSavedData lsd = new LevelSavedData();
                    ssd.levelSavedData.Add(lsd);
                }
                SaveLoad.savegame.stadiumsSavedData.Add(ssd);
            }
            Save();
        }

        if (File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
            SaveLoad.savegame = (Savegame)bf.Deserialize(file);
            //SaveLoad.savegames = (List<Savegame>)bf.Deserialize(file);
            file.Close();
        }
    }
}
