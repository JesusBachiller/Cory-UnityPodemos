using UnityEngine;
using System.Collections;

public class Game  {

    private static Level currentLevel;
    //private static bool camFollowsPlayer;
    public static bool cameraFollowsPlayer = true;

    public static bool coryDie = false;

    public static bool coryFly = false;


    public static Level getCurrentLevel()
    {
        return currentLevel;
    }
    public static void setCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    public static void resetAllValues()
    {
        currentLevel = null;
        cameraFollowsPlayer = true;
        coryDie = false;
        coryFly = false;
    }
}
