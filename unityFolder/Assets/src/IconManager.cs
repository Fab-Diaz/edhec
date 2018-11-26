using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour {

    private bool hideIcons = true;
    private bool isUp = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hideIcons)
        {
            foreach (Transform child in GameObject.Find("Icons").transform)
            {
                if (child.GetComponent<ShopPopup>())
                    child.GetComponent<ShopPopup>().hide = true;
            }
            foreach (Transform child in GameObject.Find("shops").transform)
            {
                foreach (Transform subChild in child.transform)
                {
                    if (subChild.GetComponent<ShopPopup>())
                        subChild.GetComponent<ShopPopup>().hide = false;
                }
            }
        }
        else
        {
            foreach (Transform child in GameObject.Find("Icons").transform)
            {
                print(child.name);
                if (child.GetComponent<ShopPopup>())
                    child.GetComponent<ShopPopup>().hide = false;
            }
            foreach (Transform child in GameObject.Find("shops").transform)
            {
                foreach (Transform subChild in child.transform)
                {
                    if (subChild.GetComponent<ShopPopup>())
                        subChild.GetComponent<ShopPopup>().hide = true;
                }
            }

        }
    }

    void OnTouchDown()
    {
        if (isUp)
        {
            hideIcons = !hideIcons;
            isUp = false;
        }
    }

    void OnTouchUp()
    {
        isUp = true;
    }

    void OnTouchStay()
    {
        if (isUp)
        {
            hideIcons = !hideIcons;
            isUp = false;
        }
    }

    void OnTouchExit()
    {
        isUp = true;
    }
}
