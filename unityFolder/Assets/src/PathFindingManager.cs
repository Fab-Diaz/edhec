using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingManager : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
    }

    void OnTouchDown()
    {
        if (!GameObject.Find("mapLevel1").GetComponent<PathFinding>().enabled)
        {
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().enabled = true;
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().find = true;
        }
        else
        {
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().enabled = false;
            foreach (Transform child in GameObject.Find("shops").transform)
            {
                if (child.GetComponent<Button>())
                    child.GetComponent<Button>().cleanIt = 3;
            }
            foreach (Transform child in GameObject.Find("Z3").transform)
            {
                if (child.GetComponent<MeshRenderer>())
                    child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    void OnTouchUp()
    {
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
