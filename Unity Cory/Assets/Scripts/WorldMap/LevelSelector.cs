using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour {

    private bool visible;

	// Use this for initialization
	void Start () {
        visible = false;
	}
	
	public bool getVisible()
    {
        return visible;
    }
    public void setVisible(bool b)
    {
        visible = b;
    }
    
}
