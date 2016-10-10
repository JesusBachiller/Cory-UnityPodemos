using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {
    
    Stadium[] stadiums;

    // Use this for initialization
    void Start()
    {
        Stadiums stdms = new Stadiums();
        // Create list of stadiums
        stadiums[0] = stdms.getTutorialStadium();
        /*stadiums[1] = getFootballStadium();
        stadiums[2] = getWaterpoloStadium();
        stadiums[3] = getGolfStadium();
        stadiums[4] = getRugbyStadium();*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Stadium getStadium(int numberOfStadium)
    {
        return stadiums[numberOfStadium];
    }


}
