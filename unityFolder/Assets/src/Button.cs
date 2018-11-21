using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Color defaultColour;
    public Color selectedColour;
    public int cleanIt = 0;
    private Material mat;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
        if (PlayerPrefs.HasKey(this.name + "_color"))
            selectedColour = new Color(
                PlayerPrefs.GetFloat(this.name + "_color_r"),
                PlayerPrefs.GetFloat(this.name + "_color_g"),
                PlayerPrefs.GetFloat(this.name + "_color_b"));
        else
        {
            float color_r = Random.Range(0.2f, 1);
            float color_g = Random.Range(0.2f, 1);
            float color_b = Random.Range(0.2f, 1);
            selectedColour = new Color(color_r, color_g, color_b);
            PlayerPrefs.SetFloat(this.name + "_color_r", color_r);
            PlayerPrefs.SetFloat(this.name + "_color_g", color_g);
            PlayerPrefs.SetFloat(this.name + "_color_b", color_b);
            PlayerPrefs.SetInt(this.name + "_color", 1);
        }
        mat.color = selectedColour;
    }

    private void Update()
    {
        if (cleanIt == 1)
        {
            mat.color = new Color(1, 1, 1);
            cleanIt = 2;
        }
        else if (cleanIt == 3)
        {
            mat.color = selectedColour;
            cleanIt = 0;
        }
    }
    void OnTouchDown()
    {
        GameObject.Find("shopTitle").GetComponent<TextMesh>().text = this.name;
        mat.color = selectedColour;
    }

    void OnTouchUp()
    {
        //mat.color = defaultColour;
    }

    void OnTouchStay()
    {
        GameObject.Find("shopTitle").GetComponent<TextMesh>().text = this.name;
        mat.color = selectedColour;
    }

    void OnTouchExit()
    {
        //mat.color = defaultColour;
    }
}
