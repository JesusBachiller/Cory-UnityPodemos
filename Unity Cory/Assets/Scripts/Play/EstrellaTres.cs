using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EstrellaTres : MonoBehaviour
{
    private int priceStar;

    public GameObject NumAnimStar;

    public bool check;
    // Use this for initialization
    void Start()
    {
        priceStar = 25;

        checkIfAchieved();

        check = false;
    }

    void Update()
    {
        if (Game.getCoryDie())
        {
            StartCoroutine(waitAndCheckIfAchieved(2f));
        }
        if (!Game.getCoryFly())
        {
            checkIfAchieved();
        }
    }

    void checkIfAchieved()
    {
        if (check)
        {
            Game.setScore(Game.getScore() - priceStar);

            GameObject ScoreCanvas = GameObject.Find("Score");
            ScoreCanvas.GetComponent<Text>().text = ("Score: " + Game.getScore());

            check = false;

        }

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].thirdStarAchieved)
        {
            Game.setThirdStarOfLevelAchieved(true);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = new Color32(204, 153, 0, 1); // naranja
            }
        }
        else
        {
            Game.setThirdStarOfLevelAchieved(false);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.white;
            }
        }
    }

    IEnumerator waitAndCheckIfAchieved(float s)
    {
        yield return new WaitForSeconds(s);

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].thirdStarAchieved)
        {
            Game.setThirdStarOfLevelAchieved(true);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = new Color32(204, 153, 0, 1); // naranja
            }
        }
        else
        {
            Game.setThirdStarOfLevelAchieved(false);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.white;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!Game.getCoryDie() && !Game.getCoryEnd())
            {
                if (!check)
                {
                    AudioSource audio = gameObject.AddComponent<AudioSource>();
                    audio.PlayOneShot((AudioClip)Resources.Load("Star1"));
                    Game.setThirdStarOfLevelAchieved(true);
                    check = true;
                    foreach (Material m in GetComponent<Renderer>().materials)
                    {
                        m.color = Color.yellow;
                    }

                    GameObject padre = transform.parent.gameObject;
                    padre.GetComponentInChildren<ParticleSystem>().Play();
                    
                    Game.setScore(Game.getScore() + priceStar);

                    GameObject ScoreCanvas = GameObject.Find("Score");
                    ScoreCanvas.GetComponent<Text>().text = ("Score: " + Game.getScore());

                    animNumbers(NumAnimStar);
                }
            }
        }
    }

    public void animNumbers(GameObject numanim)
    {
        GameObject NA = Instantiate(numanim, transform.position, Quaternion.identity) as GameObject;

        Destroy(NA, 0.8f);

    }
}
