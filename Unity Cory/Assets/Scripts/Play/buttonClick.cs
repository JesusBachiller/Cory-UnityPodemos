using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour {

    public int indexButton;

    public GameObject creaEscenario;
    

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
            }
            else
            {
                ClearColor();

                Game.setBotonMuelleActivado(indexButton, false);

                Game.setMuellePuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyMuelle(indexButton);
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

            }
            else
            {
                ClearColor();

                Game.setBotonAceleradorActivado(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyAcelerador(indexButton);

                Game.setAceleradorPuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleAceleradores();
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

            }
            else
            {
                ClearColor();

                Game.setBotonFireStateActivado(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyFireState(indexButton);

                Game.setFireStatePuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleFireState();
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

            }
            else
            {
                ClearColor();

                Game.setBotonIceStateActivado(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().DestroyIceState(indexButton);

                Game.setIceStatePuesto(indexButton, false);

                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleIceState();
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
            }
        }
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
}
