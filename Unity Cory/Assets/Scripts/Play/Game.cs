using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game  {

    private static Level currentLevel;
    private static Stadium currentStadium;

    private static List<Level> StadiumLevels;
    
    public static bool cameraFollowsPlayer = true;

    private static bool coryDie = false;
    private static bool coryFly = false;
    private static bool coryEnd = false;

    private static bool firstStarOfLevelAchieved = false;
    private static bool secondStarOfLevelAchieved = false;
    private static bool thirdStarOfLevelAchieved = false;

    private static int numMuellesTotales = 2;
    private static bool[] muellePuesto = new bool[numMuellesTotales];
    private static bool[] botonMuelleActivo = new bool[numMuellesTotales];

    private static int numAceleradoresTotales = 3;
    private static bool[] aceleradorPuesto = new bool[numAceleradoresTotales];
    private static bool[] botonAceleradorActivo = new bool[numAceleradoresTotales];
    


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
    public static Stadium getCurrentStadium()
    {
        return currentStadium;
    }
    public static void setCurrentStadium(Stadium stadium)
    {
        currentStadium = stadium;
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

    public static bool getFirstStarOfLevelAchieved()
    {
        return firstStarOfLevelAchieved;
    }
    public static void setFirstStarOfLevelAchieved(bool B)
    {
        firstStarOfLevelAchieved = B;
    }

    public static bool getSecondStarOfLevelAchieved()
    {
        return secondStarOfLevelAchieved;
    }
    public static void setSecondStarOfLevelAchieved(bool B)
    {
        secondStarOfLevelAchieved = B;
    }
    
    public static bool getThirdStarOfLevelAchieved()
    {
        return thirdStarOfLevelAchieved;
    }
    public static void setThirdStarOfLevelAchieved(bool B)
    {
        thirdStarOfLevelAchieved = B;
    }

    public static bool getCoryFly()
    {
        return coryFly;
    }
    public static void setCoryFly(bool B)
    {
        coryFly = B;
    }
    

    public static int getNumMuelles()
    {
        return numMuellesTotales;
    }
    public static void setNumMuelles(int N)
    {
        numMuellesTotales = N;
    }

    public static int getNumAceleradores()
    {
        return numAceleradoresTotales;
    }
    public static void setNumAceleradores(int N)
    {
        numAceleradoresTotales = N;
    }

    public static bool getMuellePuesto(int index)
    {
        return muellePuesto[index];
    }
    public static void setMuellePuesto(int index, bool b)
    {
        muellePuesto[index] = b;
    }

    public static bool getAceleradorPuesto(int index)
    {
        return aceleradorPuesto[index-numMuellesTotales];
    }
    public static void setAceleradorPuesto(int index, bool b)
    {
        aceleradorPuesto[index - numMuellesTotales] = b;
    }


    public static bool getBotonMuelleActivado(int index)
    {
        return botonMuelleActivo[index];
    }
    public static void setBotonMuelleActivado(int index, bool b)
    {
        botonMuelleActivo[index] = b;
    }

    public static bool getBotonAceleradorActivado(int index)
    {
        return botonAceleradorActivo[index - numMuellesTotales];
    }
    public static void setBotonAceleradorActivado(int index, bool b)
    {
        botonAceleradorActivo[index - numMuellesTotales] = b;
    }

    public static void resetAllValues()
    {
        cameraFollowsPlayer = true;
        coryDie = false;
        coryFly = false;
        coryEnd = false;

        firstStarOfLevelAchieved = false;
        secondStarOfLevelAchieved = false;
        thirdStarOfLevelAchieved = false;

        numMuellesTotales = 2;
        muellePuesto = new bool[numMuellesTotales];
        botonMuelleActivo = new bool[numMuellesTotales];

        numAceleradoresTotales = 3;
        aceleradorPuesto = new bool[numAceleradoresTotales];
        botonAceleradorActivo = new bool[numAceleradoresTotales];
    }
}
