using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game  {

    public static List<Stadium> stadiums;
    private static Level currentLevel;
    private static Stadium currentStadium;
    
    public static bool cameraFollowsPlayer = true;

    private static bool coryDie = false;
    private static bool coryFly = false;
    private static bool coryEnd = false;

    private static bool firstStarOfLevelAchieved = false;
    private static bool secondStarOfLevelAchieved = false;
    private static bool thirdStarOfLevelAchieved = false;
    
    private static bool commentsEnabled = false;

    /* Esto coge valor al arrancar un nivel en setCurrentLevel y se resetea en resetAllValues */
    private static int numMuellesTotales = 0;
    private static bool[] muellePuesto = null;
    private static bool[] botonMuelleActivo = null;

    private static int numAceleradoresTotales = 0;
    private static bool[] aceleradorPuesto = null;
    private static bool[] botonAceleradorActivo = null;
    /* Esto coge valor al arrancar un nivel en setCurrentLevel y se resetea en resetAllValues */

    public static void LoadStadiums()
    {
        StadiumContainer sc = StadiumContainer.Load();
        sc.LoadLevelsOfStadiums();
        stadiums = sc.stadiums;
        foreach (Stadium s in stadiums)
        {
            foreach(Level l in s.levels)
            {
                if(l.xmlCommentsPath != null && l.xmlCommentsPath != "")
                {
                    l.comments = CommentsContainer.Load(l.xmlCommentsPath).comments;
                }
            }
        }
    }

    public static int getCurrentStadiumLevelQuatity()
    {
        return stadiums[currentStadium.index].levels.Count;
    }

    public static List<Level> getStadiumLevels()
    {
        return stadiums[currentStadium.index].levels;
    }

    public static Level getCurrentLevel()
    {
        return currentLevel;
    }
    public static void setCurrentLevel(Level level)
    {
        if (level == null)
        {
            numMuellesTotales = 0;
            muellePuesto = null;
            botonMuelleActivo = null;

            numAceleradoresTotales = 0;
            aceleradorPuesto = null;
            botonAceleradorActivo = null;
        } else
        {
            numMuellesTotales = level.availableSprings;
            muellePuesto = new bool[numMuellesTotales];
            botonMuelleActivo = new bool[numMuellesTotales];

            numAceleradoresTotales = level.availableAccelerators;
            aceleradorPuesto = new bool[numAceleradoresTotales];
            botonAceleradorActivo = new bool[numAceleradoresTotales];
        }

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
    
    public static bool getCommentsEnabled()
    {
        return commentsEnabled;
    }
    public static void setCommentsEnabled(bool B)
    {
        commentsEnabled = B;
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

        numMuellesTotales = 0;
        muellePuesto = null;
        botonMuelleActivo = null;

        numAceleradoresTotales = 0;
        aceleradorPuesto = null;
        botonAceleradorActivo = null;
    }
}
