using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stadium : MonoBehaviour {
    
    private string stadiumName;
    private int minStarsToUnlock;
    private Level[] levels;

    public Stadium(string stadiumName, int minStarsToUnlock, Level[] levels)
    {
        this.stadiumName = stadiumName;
        this.minStarsToUnlock = minStarsToUnlock;
        this.levels = levels;
    }

    public Level getLevel(int numberOfTheLevel)
    {
        return levels[numberOfTheLevel];
    }
}
