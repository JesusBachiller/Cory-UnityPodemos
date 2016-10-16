using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDHerramientas : MonoBehaviour
{

    public Button MuelleButton;
    public Button AceleradorButton;

    private bool selectToolBoolean;
    private string selectedToolString;

    // Use this for initialization
    void Start()
    {
        MuelleButton.onClick.AddListener(changeMuelleOnSelect);
        AceleradorButton.onClick.AddListener(changeAceleradorOnSelect);
        selectToolBoolean = false;
        selectedToolString = "";
    }

    public bool getSelectToolBoolean()
    {
        return selectToolBoolean;
    }
    public void setSelectToolBoolean(bool B)
    {
        selectToolBoolean = B;
    }

    public string getSelectToolString()
    {
        return selectedToolString;
    }
    public void setSelectToolString(string S)
    {
        selectedToolString = S;
    }


    private void changeMuelleOnSelect()
    {
        if (!selectToolBoolean)
        {
            ColorBlock cb = MuelleButton.colors;
            cb.normalColor = Color.Lerp(Color.white, Color.black, 0.50f);
            cb.highlightedColor = Color.Lerp(Color.white, Color.black, 0.50f);
            MuelleButton.colors = cb;

            selectToolBoolean = true;
            selectedToolString = "Muelle";
            Game.setSelectedTool(selectedToolString);
        }
        else
        {
            if(selectedToolString == "Muelle")
            {
                ColorBlock cb = MuelleButton.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = Color.white;
                MuelleButton.colors = cb;

                selectToolBoolean = false;
                selectedToolString = "";
                Game.setSelectedTool(selectedToolString);
            }
        }
    }

    public void changeAceleradorOnSelect()
    {
        if (!selectToolBoolean)
        {
            ColorBlock cb = AceleradorButton.colors;
            cb.normalColor = Color.Lerp(Color.white, Color.black, 0.50f);
            cb.highlightedColor = Color.Lerp(Color.white, Color.black, 0.50f);
            AceleradorButton.colors = cb;

            selectToolBoolean = true;
            selectedToolString = "Acelerador";
            Game.setSelectedTool(selectedToolString);
        }
        else
        {
            if (selectedToolString == "Acelerador")
            {
                ColorBlock cb = AceleradorButton.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = Color.white;
                AceleradorButton.colors = cb;

                selectToolBoolean = false;
                selectedToolString = "";
                Game.setSelectedTool(selectedToolString);
            }
        }
    }
}
