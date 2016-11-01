using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour {

    public int indexButton;

    public GameObject creaEscenario;
    

    private bool permitirClick()
    {
        bool permite = true;
        for (int i = 0; i < Game.getNumMuelles(); i++)
        {
            if(i != indexButton)
                {
                if (Game.getBotonMuelleActivado(i) == true && Game.getMuellePuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }
        if (permite) {
            for (int i = Game.getNumMuelles(); i < Game.getNumMuelles() + Game.getNumAceleradores(); i++)
            {
                if (i != indexButton)
                {
                    Debug.Log(i);
                    if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
                    {
                        permite = false;
                        break;
                    }
                }
            }
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
        cb.normalColor = Color.Lerp(Color.white, Color.black, 0.20f);
        cb.highlightedColor = Color.Lerp(Color.white, Color.black, 0.20f);
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
