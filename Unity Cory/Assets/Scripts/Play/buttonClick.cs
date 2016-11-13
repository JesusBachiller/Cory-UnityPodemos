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

            for (int i = 0; i < Game.getNumMuelles(); i++)
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
            if (permite)
            {
                for (int i = Game.getNumMuelles(); i < Game.getNumMuelles() + Game.getNumAceleradores(); i++)
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
                if (permite)
                {
                    for (int i = Game.getNumMuelles() + Game.getNumAceleradores(); i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState(); i++)
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
