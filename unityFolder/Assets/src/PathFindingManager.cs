using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingManager : MonoBehaviour
{

    public int openManager = 0;
    private GameObject gpsList;
    private int bounce = 0;
    // Use this for initialization
    void Start()
    {
        gpsList = GameObject.Find("gpsList");
    }

    private void Update()
    {
        if (openManager == 1)
        {
            if ((gpsList.transform.position.y < -90 && bounce == 0))
                gpsList.transform.position = new Vector3(gpsList.transform.position.x, gpsList.transform.position.y + 4f, gpsList.transform.position.z);
            else if (gpsList.transform.position.y >= -90 && bounce == 0)
                bounce = 1;
            else if ((gpsList.transform.position.y > -93 && bounce == 1))
                gpsList.transform.position = new Vector3(gpsList.transform.position.x, gpsList.transform.position.y - 0.6f, gpsList.transform.position.z);
            else
            {
                openManager = 2;
                gpsList.GetComponent<MoveInput>().refreshPos = true;
            }
        }
        else if (openManager == 3)
        {
            if (gpsList.transform.position.y > -178)
                gpsList.transform.position = new Vector3(gpsList.transform.position.x, gpsList.transform.position.y - 7f, gpsList.transform.position.z);
            else
            {
                bounce = 0;
                openManager = 0;
                gpsList.GetComponent<MoveInput>().refreshPos = true;
            }
        }
    }
    void OnTouchDown()
    {
        if (openManager == 0)
        {
            openManager = 1;
            for (int i = 0; GameObject.Find("R3 (" + i + ")"); i++)
                GameObject.Find("R3 (" + i + ")").GetComponent<MeshRenderer>().enabled = false;
            foreach (Transform child in GameObject.Find("shops").transform)
                child.GetComponent<Button>().cleanIt = 3;
            GameObject.Find("R" + GameObject.Find("mapLevel1").GetComponent<PathFinding>().from.name).GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("R" + GameObject.Find("mapLevel1").GetComponent<PathFinding>().to.name).GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().from = null;
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().to = null;
            GameObject.Find("mapLevel1").GetComponent<PathFinding>().enabled = false;
        }
        else if (openManager == 2)
            openManager = 3;
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
