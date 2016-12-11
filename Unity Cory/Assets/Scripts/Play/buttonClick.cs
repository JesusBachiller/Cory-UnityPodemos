using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour {

    public int indexButton;

    public GameObject creaEscenario;
    public GameObject NumAnimRest;
    public GameObject NumAnimSum;
    public GameObject CanvasButtons;

    private GameObject ScoreCanvas;
    public int myPrice;
    public GameObject PriceObj;

    
    public void Start()
    {
        myPrice = 100;
        PriceObj = GameObject.Find("Price(Clone)");
        CanvasButtons = GameObject.Find("HerramientasHUD");
        ScoreCanvas = GameObject.Find("Score");
    }
    private bool permitirClick()
    {
        bool permite = false;
        if (!Game.getCommentsEnabled())
        {
            permite = true;

            for (int i = 0;
                     i < Game.getNumMuelles();
                     i++)
            {
                if (i != indexButton)
                {
                    if (Game.getBotonMuelleActivado(i) == true && Game.getMuellePuesto(i) == false)
                    {
                        permite = false;
                        return permite; 
                    }
                }
            }

            for (int i = Game.getNumMuelles();
                     i < Game.getNumMuelles() + Game.getNumAceleradores();
                     i++)
            {
                if (i != indexButton)
                {
                    if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
                    {
                        permite = false;
                        return permite;
                    }
                }
            }

            for (int i = Game.getNumMuelles() + Game.getNumAceleradores();
                     i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                     i++)
            {
                if (i != indexButton)
                {
                    if (Game.getBotonFireStateActivado(i) == true && Game.getFireStatePuesto(i) == false)
                    {
                        permite = false;
                        return permite;
                    }
                }
            }

            for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                     i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
                     i++)
            {
                if (i != indexButton)
                {
                    if (Game.getBotonIceStateActivado(i) == true && Game.getIceStatePuesto(i) == false)
                    {
                        permite = false;
                        break;
                    }
                }
            }

            for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
                     i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState() + Game.getNumPortales();
                     i++)
            {
                if (i != indexButton)
                {
                    if (Game.getBotonPortalActivado(i) == true && Game.getPortalEntradaPuesto(i) == false)
                    {
                        permite = false;
                        break;
                    }
                    if (Game.getBotonPortalActivado(i) == true && Game.getPortalSalidaPuesto(i) == false)
                    {
                        permite = false;
                        break;
                    }
                }
            }
        }

        if(Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie())
        {
            permite = false;
            return permite;
        }

        return permite;
    }
    

    public void onClickMuelle()
    {
        bool permiteClick = permitirClick();

        if (permiteClick)
        {
            if (!Game.getBotonMuelleActivado(indexButton))
            {
                DarkColor();

                Game.setBotonMuelleActivado(indexButton, true);

                animNumbers(transform.position, NumAnimRest);
                StartCoroutine(ActualizaScore(1.255f, -myPrice));
            }
            else
            {
                ClearColor();

                Game.setBotonMuelleActivado(indexButton, false);

                Game.setMuellePuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyMuelle(indexButton);

                animNumbers(transform.position, NumAnimSum);
                StartCoroutine(ActualizaScore(0f, myPrice));
            }
        }
            
    }

    public void onClickAcelerador()
    {
        bool permiteClick = permitirClick();

        if (permiteClick)
        {
            if (!Game.getBotonAceleradorActivado(indexButton))
            {
                DarkColor();

                Game.setBotonAceleradorActivado(indexButton, true);

                creaEscenario.GetComponent<ActualizaEscenario>().InstanciateAcelerador(indexButton);

                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossibleAcelerador();
                
                animNumbers(transform.position, NumAnimRest);
                StartCoroutine(ActualizaScore(1.255f, -myPrice));

            }
            else
            {
                ClearColor();

                Game.setBotonAceleradorActivado(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyAcelerador(indexButton);

                Game.setAceleradorPuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleAceleradores();

                animNumbers(transform.position, NumAnimSum);
                StartCoroutine(ActualizaScore(0f, myPrice));
            }
        }
    }

    public void onClickFireState()
    {
        bool permiteClick = permitirClick();

        if (permiteClick)
        {
            if (!Game.getBotonFireStateActivado(indexButton))
            {
                DarkColor();

                Game.setBotonFireStateActivado(indexButton, true);

                creaEscenario.GetComponent<ActualizaEscenario>().InstanciateFireState(indexButton);

                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossibleFireState();

                animNumbers(transform.position, NumAnimRest);
                StartCoroutine(ActualizaScore(1.255f, -myPrice));
            }
            else
            {
                ClearColor();

                Game.setBotonFireStateActivado(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyFireState(indexButton);

                Game.setFireStatePuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleFireState();

                animNumbers(transform.position, NumAnimSum);
                StartCoroutine(ActualizaScore(0f, myPrice));
            }
        }
    }

    public void onClickIceState()
    {
        bool permiteClick = permitirClick();

        if (permiteClick)
        {
            if (!Game.getBotonIceStateActivado(indexButton))
            {
                DarkColor();

                Game.setBotonIceStateActivado(indexButton, true);

                creaEscenario.GetComponent<ActualizaEscenario>().InstanciateIceState(indexButton);

                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossibleIceState();

                animNumbers(transform.position, NumAnimRest);
                StartCoroutine(ActualizaScore(1.255f, -myPrice));
            }
            else
            {
                ClearColor();

                Game.setBotonIceStateActivado(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyIceState(indexButton);

                Game.setIceStatePuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleIceState();

                animNumbers(transform.position, NumAnimSum);
                StartCoroutine(ActualizaScore(0f, myPrice));
            }
        }
    }

    public void onClickPortal()
    {
        bool permiteClick = permitirClick();

        if (permiteClick)
        {
            if (!Game.getBotonPortalActivado(indexButton))
            {
                DarkColor();

                Game.setBotonPortalActivado(indexButton, true);

                creaEscenario.GetComponent<ActualizaEscenario>().InstanciatePortalEntrada(indexButton);

                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossiblePortalEntrada();

                animNumbers(transform.position, NumAnimRest);
                StartCoroutine(ActualizaScore(1.255f, -myPrice));
            }
            else
            {
                ClearColor();

                Game.setBotonPortalActivado(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyPortal(indexButton);

                PortalEntrada.hideAllIndicators();

                Game.setPortalEntradaPuesto(indexButton, false);
                Game.setPortalSalidaPuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossiblePortalEntrada();
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossiblePortalSalida();

                animNumbers(transform.position, NumAnimSum);
                StartCoroutine(ActualizaScore(0f, myPrice));
            }
        }
    }

    public void onMouseEnter()
    {
        if(PriceObj == null)
{
            PriceObj = GameObject.Find("Price(Clone)");
        }
        if (!(Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie()))
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            PriceObj.GetComponentInChildren<Text>().text = myPrice.ToString();
            PriceObj.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 13, transform.localPosition.z);
        }
    }
    public void onMouseExit()
    {
        if (!(Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie()))
        {
            transform.localScale = new Vector3(0.84f, 0.84f, 0.84f);
            PriceObj.transform.position = new Vector3(-5f, -5f - 5f);
        }
    }

    public void animNumbers(Vector3 posIni, GameObject numanim)
    {
        GameObject NA = Instantiate(numanim, posIni, Quaternion.identity) as GameObject;
        NA.GetComponent<Text>().text = myPrice.ToString();
        NA.transform.parent = CanvasButtons.transform;


        Destroy(NA, 1.255f);

    }
    
    private void ClearColor()
    {
        ColorBlock cb = gameObject.GetComponent<Button>().colors;
        cb.normalColor = Color.white;
        cb.highlightedColor = Color.white;
        gameObject.GetComponent<Button>().colors = cb;
    }
    private void DarkColor()
    {
        ColorBlock cb = gameObject.GetComponent<Button>().colors;
        cb.normalColor = Color.Lerp(Color.white, Color.black, 0.70f);
        cb.highlightedColor = Color.Lerp(Color.white, Color.black, 0.70f);
        gameObject.GetComponent<Button>().colors = cb;
    }

    public void setIndex(int i)
    {
        indexButton = i;
    }
    public int getIndex()
    {
        return indexButton;
    }

    IEnumerator ActualizaScore(float s, int price)
    {
        yield return new WaitForSeconds(s);
        
        Game.setScore(Game.getScore() + price);

        GameObject ScoreCanvas = GameObject.Find("Score");
        ScoreCanvas.GetComponent<Text>().text = ("Score: " + Game.getScore());
    }
}
