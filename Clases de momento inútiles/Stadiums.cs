using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Stadiums : MonoBehaviour {
    Levels lvls;
    
    // Use this for initialization
    void Start()
    {
        lvls = new Levels();
    }

    public Stadium getTutorialStadium()
    {
        Level[] levels = new Level[0];
        levels[0] = lvls.getTestLevel();
        // Add here more levels to this stadium
        return new Stadium("Tutorial Stadium", 0, levels);
    }

    // Add here more stadiums...

  
}
