using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game  {

    private static Level currentLevel;

    private static List<Level> StadiumLevels;
    
    public static bool cameraFollowsPlayer = true;

    private static bool coryDie = false;
    private static bool coryFly = false;
    private static bool coryEnd = false;

    private static string selectedTool = "";

    public static List<Level> getStadiumLevels()
    {
        return StadiumLevels;
    }
    public static void setStadiumLevels(List<Level> SL)
    {
        StadiumLevels = SL;
    }

    public static Level getCurrentLevel()
    {
        return currentLevel;
    }
    public static void setCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    public static bool getCoryEnd()
    {
        return coryEnd;
    }
    public static void setCoryEnd(bool B)
    {
        coryEnd = B;
    }

    public static bool getCoryDie()
    {
        return coryDie;
    }
    public static void setCoryDie(bool B)
    {
        coryDie = B;
    }
    
    public static bool getCoryFly()
    {
        return coryFly;
    }
    public static void setCoryFly(bool B)
    {
        coryFly = B;
    }

    public static string getSelectedTool()
    {
        return selectedTool;
    }
    public static void setSelectedTool(string S)
    {
        selectedTool = S;
    }

    public static void resetAllValues()
    {
        cameraFollowsPlayer = true;
        coryDie = false;
        coryFly = false;
        coryEnd = false;
        selectedTool = "";
    }
}
