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

    private static string coryState = "noState";

    private static bool firstStarOfLevelAchieved = false;
    private static bool secondStarOfLevelAchieved = false;
    private static bool thirdStarOfLevelAchieved = false;
    
    private static bool commentsEnabled = false;

    private static int score = 0;

    /* Esto coge valor al arrancar un nivel en setCurrentLevel y se resetea en resetAllValues */
    private static int numMuellesTotales = 0;
    private static bool[] muellePuesto = null;
    private static bool[] botonMuelleActivo = null;

    private static int numAceleradoresTotales = 0;
    private static bool[] aceleradorPuesto = null;
    private static bool[] botonAceleradorActivo = null;

    private static int numPortalesTotales = 0;
    private static bool[] portalEntradaPuesto = null;
    private static bool[] portalSalidaPuesto = null;
    private static bool[] botonPortalActivo = null;
    private static bool[] coryInsidePortal = null;
    public const int RADIO_MAX_PORTALES = 5;

    private static int numFireStateTotales = 0;
    private static bool[] FireStatePuesto = null;
    private static bool[] botonFireStateActivo = null;
    
    private static int numIceStateTotales = 0;
    private static bool[] IceStatePuesto = null;
    private static bool[] botonIceStateActivo = null;
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

    public static bool isCoryInsideSomePortal()
    {
        if (coryInsidePortal == null)
        {
            return false;
        } else
        {
            foreach(bool b in coryInsidePortal)
            {
                if (b)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public static void coryIsNotInsideAnyPortal()
    {
        if (coryInsidePortal != null)
        {
            for(int i = 0; i < coryInsidePortal.Length -1; i++)
            {
                coryInsidePortal[i] = false;
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
            score = 0;

            numMuellesTotales = 0;
            muellePuesto = null;
            botonMuelleActivo = null;

            numAceleradoresTotales = 0;
            aceleradorPuesto = null;
            botonAceleradorActivo = null;

            numFireStateTotales = 0;
            FireStatePuesto = null;
            botonFireStateActivo = null;

            numPortalesTotales = 0;
            portalEntradaPuesto = null;
            portalSalidaPuesto = null;
            botonPortalActivo = null;
            coryInsidePortal = null;

            numIceStateTotales = 0;
            IceStatePuesto = null;
            botonIceStateActivo = null;

        } else {

            score = level.startScore;

            numMuellesTotales = level.availableSprings;
            muellePuesto = new bool[numMuellesTotales];
            botonMuelleActivo = new bool[numMuellesTotales];

            numAceleradoresTotales = level.availableAccelerators;
            aceleradorPuesto = new bool[numAceleradoresTotales];
            botonAceleradorActivo = new bool[numAceleradoresTotales];
            
            numFireStateTotales = level.availableFireState;
            FireStatePuesto = new bool[numFireStateTotales];
            botonFireStateActivo = new bool[numFireStateTotales];


            numIceStateTotales = level.availableIceState;
            IceStatePuesto = new bool[numIceStateTotales];
            botonIceStateActivo = new bool[numIceStateTotales];

            numPortalesTotales = level.availablePortals;
            portalEntradaPuesto = new bool[numPortalesTotales];
            portalSalidaPuesto = new bool[numPortalesTotales];
            botonPortalActivo = new bool[numPortalesTotales];
            coryInsidePortal = new bool[numPortalesTotales];

            

            firstStarOfLevelAchieved = SaveLoad.savegame.stadiumsSavedData[currentStadium.index].levelSavedData[level.index].firstStarAchieved;
            secondStarOfLevelAchieved = SaveLoad.savegame.stadiumsSavedData[currentStadium.index].levelSavedData[level.index].secondStarAchieved;
            thirdStarOfLevelAchieved = SaveLoad.savegame.stadiumsSavedData[currentStadium.index].levelSavedData[level.index].thirdStarAchieved;
            

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

    public static bool getCoryFly()
    {
        return coryFly;
    }
    public static void setCoryFly(bool B)
    {
        coryFly = B;
    }

    public static string getCoryState()
    {
        return coryState;
    }
    public static void setCoryState(string s)
    {
        coryState = s;
    }


    public static bool getCommentsEnabled()
    {
        return commentsEnabled;
    }
    public static void setCommentsEnabled(bool B)
    {
        commentsEnabled = B;
    }


    public static int getScore()
    {
        return score;
    }
    public static void setScore(int newScore)
    {
        score = newScore;
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
    
    
    public static int getNumFireState()
    {
        return numFireStateTotales;
    }
    public static void setNumFireState(int N)
    {
        numFireStateTotales = N;
    }

    public static int getNumIceState()
    {
        return numIceStateTotales;
    }
    public static void setNumIceState(int N)
    {
        numIceStateTotales = N;
    }

    public static int getNumPortales()
    {
        return numPortalesTotales;
    }
    public static void setNumPortales(int N)
    {
        numPortalesTotales = N;
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
        return aceleradorPuesto[index -  numMuellesTotales];
    }
    public static void setAceleradorPuesto(int index, bool b)
    {
        aceleradorPuesto[index - numMuellesTotales] = b;
    }

    public static bool getFireStatePuesto(int index)
    {
        return FireStatePuesto[index - numMuellesTotales - numAceleradoresTotales];
    }
    public static void setFireStatePuesto(int index, bool b)
    {
        FireStatePuesto[index - numMuellesTotales - numAceleradoresTotales] = b;
    }
    
    public static bool getIceStatePuesto(int index)
    {
        return IceStatePuesto[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales];
    }
    public static void setIceStatePuesto(int index, bool b)
    {
        IceStatePuesto[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales] = b;
    }

    public static bool isCoryInsidePortal(int index)
    {

        if ((index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales) >= 0 && coryInsidePortal != null){
            return coryInsidePortal[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales];

        }
        else
        {
            return false;
        }
    }
    public static void setCoryInsidePortal(int index, bool b)
    {
        coryInsidePortal[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales] = b;
    }

    public static bool getPortalEntradaPuesto(int index)
    {
        return portalEntradaPuesto[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales];
    }
    public static void setPortalEntradaPuesto(int index, bool b)
    {
        portalEntradaPuesto[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales] = b;
    }

    public static bool getPortalSalidaPuesto(int index)
    {
        return portalSalidaPuesto[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales];
    }
    public static void setPortalSalidaPuesto(int index, bool b)
    {
        portalSalidaPuesto[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales] = b;
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

    public static bool getBotonFireStateActivado(int index)
    {
        return botonFireStateActivo[index - numMuellesTotales - numAceleradoresTotales];
    }
    public static void setBotonFireStateActivado(int index, bool b)
    {
        botonFireStateActivo[index - numMuellesTotales - numAceleradoresTotales] = b;
    }

    public static bool getBotonIceStateActivado(int index)
    {
        return botonIceStateActivo[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales];
    }
    public static void setBotonIceStateActivado(int index, bool b)
    {
        botonIceStateActivo[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales] = b;
    }

    public static bool getBotonPortalActivado(int index)
    {
        return botonPortalActivo[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales];
    }
    public static void setBotonPortalActivado(int index, bool b)
    {
        botonPortalActivo[index - numMuellesTotales - numAceleradoresTotales - numFireStateTotales - numIceStateTotales] = b;
    }

    


    public static void resetAllValues()
    {
        cameraFollowsPlayer = true;
        coryDie = false;
        coryFly = false;
        coryEnd = false;

        coryState = "noState";

        firstStarOfLevelAchieved = false;
        secondStarOfLevelAchieved = false;
        thirdStarOfLevelAchieved = false;

        numMuellesTotales = 0;
        muellePuesto = null;
        botonMuelleActivo = null;

        numAceleradoresTotales = 0;
        aceleradorPuesto = null;
        botonAceleradorActivo = null;

        numPortalesTotales = 0;
        portalEntradaPuesto = null;
        portalSalidaPuesto = null;
        botonPortalActivo = null;
        coryInsidePortal = null;

        numFireStateTotales = 0;
        FireStatePuesto = null;
        botonFireStateActivo = null;

        numIceStateTotales = 0;
        IceStatePuesto = null;
        botonIceStateActivo = null;
    }
}
