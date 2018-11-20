using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Color defaultColour;
    public Color selectedColour;
    private Material mat;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
	}
	
    void OnTouchDown()
    {
        mat.color = selectedColour;
    }

    void OnTouchUp()
    {
        mat.color = defaultColour;
    }

    void OnTouchStay()
    {
        mat.color = selectedColour;
    }

    void OnTouchExit()
    {
        mat.color = defaultColour;
    }
}
