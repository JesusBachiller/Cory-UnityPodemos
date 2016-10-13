using UnityEngine;
using System.Collections;

public class Game  {

    private static Level currentLevel;
    //private static bool camFollowsPlayer;

    public static Level getCurrentLevel()
    {
        return currentLevel;
    }
    public static void setCurrentLevel(Level level)
    {
        currentLevel = level;
    }
}
