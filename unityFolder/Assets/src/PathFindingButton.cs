using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTouchDown()
    {
        GameObject.Find("mapLevel1").GetComponent<PathFinding>().enabled = true;
        GameObject.Find("shopTitle").GetComponent<TextMesh>().text = this.name.Substring("list_".Length, this.name.Length - "list_".Length);
        if (GameObject.Find("mapLevel1").GetComponent<PathFinding>().from == null)
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().from = GameObject.Find(this.name.Substring("list_".Length, this.name.Length - "list_".Length));
        else if (GameObject.Find("mapLevel1").GetComponent<PathFinding>().to == null)
        {
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().to = GameObject.Find(this.name.Substring("list_".Length, this.name.Length - "list_".Length));
            GameObject.Find("gps").GetComponent<PathFindingManager>().openManager = 3;
        }
    }

    void OnTouchUp()
    {
        //mat.color = defaultColour;
    }

    void OnTouchStay()
    {
        GameObject.Find("mapLevel1").GetComponent<PathFinding>().enabled = true;
        if (GameObject.Find("mapLevel1").GetComponent<PathFinding>().from == null)
        {
            GameObject.Find("shopTitle").GetComponent<TextMesh>().text = "From : " + this.name.Substring("list_".Length, this.name.Length - "list_".Length);
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().from = GameObject.Find(this.name.Substring("list_".Length, this.name.Length - "list_".Length));
        }
        else if (GameObject.Find("mapLevel1").GetComponent<PathFinding>().to == null)
        {
            GameObject.Find("shopTitle").GetComponent<TextMesh>().text = "To : " + this.name.Substring("list_".Length, this.name.Length - "list_".Length);
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().to = GameObject.Find(this.name.Substring("list_".Length, this.name.Length - "list_".Length));
            GameObject.Find("gps").GetComponent<PathFindingManager>().openManager = 3;
        }
    }

    void OnTouchExit()
    {
        //mat.color = defaultColour;
    }
}
