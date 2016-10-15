using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start () {
        SaveLoad.Load();

        quitMenu = quitMenu.GetComponent<Canvas>(); 
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }
	
    public void  ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartMapScene()
    {
        SaveLoad.savegame.vecesClickadasBotonPlay += 1;
        SaveLoad.Save();
        SceneManager.LoadScene("WorldMap");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
