using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

    private float[] positionDiff = new float[3];
    private float[] scaleDiff = new float[3];
    private float time;
    private bool isPressed;
    public bool lockIt;
    private GameObject map;

    void Start()
    {
        map = GameObject.Find("mapLevel1");
        time = 0;
        isPressed = false;
        lockIt = false;
    }

    private void Update()
    {
        if (isPressed)
        {
            time += Time.deltaTime;
            if (time <= 0.60)
            {
                map.transform.position = new Vector3(map.transform.position.x - positionDiff[0], map.transform.position.y - positionDiff[1], map.transform.position.z - positionDiff[2]);
                map.transform.localScale = new Vector3(map.transform.localScale.x - scaleDiff[0], map.transform.localScale.y - scaleDiff[1], map.transform.localScale.z - scaleDiff[2]);
            }
            else
            {
                isPressed = false;
                GameObject.Find("zoomIn").GetComponent<ZoomIn>().lockIt = false;
                GameObject.Find("mapInput").GetComponent<MoveInput>().enabled = true;
            }
        }
    }

    void OnTouchDown()
    {
        if (map.transform.localScale.x >= 0.8f && !isPressed && !lockIt)
        {
            float speed = 35;
            GameObject.Find("zoomIn").GetComponent<ZoomIn>().lockIt = true;
            GameObject.Find("mapInput").GetComponent<MoveInput>().enabled = false;

            map.transform.localScale = new Vector3(1f, 1f, 1f);

            positionDiff[0] = (map.transform.position.x - (-133.3f)) / speed;
            positionDiff[1] = (map.transform.position.y - (-206f)) / speed;
            positionDiff[2] = (map.transform.position.z - (-181f)) / speed;

            scaleDiff[0] = (map.transform.localScale.x - (0.4f)) / speed;
            scaleDiff[1] = (map.transform.localScale.y - (0.4f)) / speed;
            scaleDiff[2] = 0;

            time = 0;
            isPressed = true;
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
