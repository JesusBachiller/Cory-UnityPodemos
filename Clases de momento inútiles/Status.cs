using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{
    private int currentStadium;
    private int currentLevel;

    // Use this for initialization
    void Start()
    {
        // Load currentStadium from DB, XML or txt
        currentStadium = 0;
        // Load currentLevel from DB, XML or txt
        currentLevel = 0;
    }
    
    public int getCurrentStadium()
    {
        return currentStadium;
    }
    public int getCurrentLevel()
    {
        return currentLevel;
    }
}
