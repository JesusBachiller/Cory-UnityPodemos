using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

    // Elements
    public const int AIR = 0;
    public const int STONE = 1;
    public const int GRASS = 2;
    public const int WATER = 3;
    public const int BALL = 4;
    
    // Tools
    public const int DOCK = 0;
    public const int ACCELERATOR = 1;
    public const int PORTAL = 2;

    public Level getTestLevel()
    {
        // Creating Test Level
        int[,] mapElements = {
            { STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE, STONE},
            { GRASS, GRASS, WATER, GRASS, GRASS, GRASS, GRASS, GRASS, GRASS, GRASS, GRASS, GRASS, GRASS, GRASS, GRASS, WATER, WATER, GRASS, STONE, STONE, GRASS, GRASS, GRASS, GRASS, GRASS, STONE},
            { AIR, BALL, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, STONE, STONE, AIR, AIR, AIR, AIR, AIR, GRASS},
            { AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, STONE, STONE, AIR, AIR, AIR, AIR, AIR, AIR},
            { AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, AIR, GRASS, GRASS, AIR, AIR, AIR, AIR, AIR, AIR}
        };
        int[] availableTools = new int[] { DOCK };

        return new Level("Test Level", mapElements, availableTools, 0, 0, 0); // Cargar records de bbdd, xml o txt
    }
}
