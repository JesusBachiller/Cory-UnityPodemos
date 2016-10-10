using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    private string Name;
    private int[,] mapElements;
    private int[] availableTools;
    private int minStarsToUnlock;
    private int maxScore;
    private int fastestTime;

    public Level (string name, int[,] mapElements, int[] availableTools, int minStarsToUnlock, int maxScore = 0, int fastestTime = 0)
    {
        this.name = name;
        this.mapElements = mapElements;
        this.availableTools = availableTools;
        this.minStarsToUnlock = minStarsToUnlock;
        this.maxScore = maxScore;
        this.fastestTime = fastestTime;
    }
    
    public int[,] getMapElements()
    {
        return mapElements;
    }
}
