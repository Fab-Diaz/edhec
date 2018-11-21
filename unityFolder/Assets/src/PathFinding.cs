using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

    public GameObject from;
    public GameObject to;
    private GameObject towerFrom;
    private GameObject towerTo;
    private GameObject tmpTower;
    private GameObject route;

    private bool toRight = true;
    public bool find = false;
	// Use this for initialization
	void Start () {
        findIt();
    }

    void findIt()
    {
        float towerPos = 0;
        float posDiff = 0;
        float routePos = 0;

        foreach (Transform child in GameObject.Find("shops").transform)
        {
            if (child.GetComponent<Button>() && child.name != from.name && child.name != to.name)
                child.GetComponent<Button>().cleanIt = 1;
        }

        for (int i = 0; GameObject.Find("T3 (" + i + ")"); i++)
        {
            if (Mathf.Abs(GameObject.Find("T3 (" + i + ")").transform.position.x - from.transform.position.x) < 0.1f)
            {
                GameObject.Find("R" + from.name).GetComponent<MeshRenderer>().enabled = true;
                towerFrom = GameObject.Find("T3 (" + i + ")");
            }
            if (Mathf.Abs(GameObject.Find("T3 (" + i + ")").transform.position.x - to.transform.position.x) < 0.1f)
            {
                GameObject.Find("R" + to.name).GetComponent<MeshRenderer>().enabled = true;
                towerTo = GameObject.Find("T3 (" + i + ")");
            }
        }
        if (towerFrom.transform.position.x > towerTo.transform.position.x)
            toRight = false;
        while (towerFrom.transform != towerTo.transform)
        {
            towerPos = 0;
            for (int i = 0; GameObject.Find("T3 (" + i + ")"); i++)
            {
                posDiff = Mathf.Abs(GameObject.Find("T3 (" + i + ")").transform.position.x - towerFrom.transform.position.x);
                if (GameObject.Find("T3 (" + i + ")").transform.position.y == towerFrom.transform.position.y && (posDiff < towerPos || towerPos == 0) && GameObject.Find("T3 (" + i + ")") != towerFrom
                && ((toRight && GameObject.Find("T3 (" + i + ")").transform.position.x > towerFrom.transform.position.x) || (!toRight && GameObject.Find("T3 (" + i + ")").transform.position.x < towerFrom.transform.position.x)))
                {
                    towerPos = posDiff;
                    tmpTower = GameObject.Find("T3 (" + i + ")");
                }
            }
            routePos = (towerFrom.transform.position.x + tmpTower.transform.position.x) / 2;
            for (int i = 0; GameObject.Find("R3 (" + i + ")"); i++)
            {
                if ((GameObject.Find("R3 (" + i + ")").transform.position.x - routePos) < 0.1f)
                {
                    GameObject.Find("R3 (" + i + ")").GetComponent<MeshRenderer>().enabled = true;
                    break;
                }
            }
            print(tmpTower);
            towerFrom = tmpTower;
        }
    }
    // Update is called once per frame
    void Update () {
		if (find)
        {
            findIt();
            find = false;
        }
	}
}
