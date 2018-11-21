using UnityEngine;
using System.Collections;

public class MoveInput : MonoBehaviour {
    [SerializeField]
    float _horizontallimit = 2.5f, _verticallimit = -2.5f, dragSpeed = 0.1f;
    Transform cachedTransform;
    Vector3 startingPos;
    private Vector2 deltaPosition;
    private Vector3 initialPosition;
    private float time = 0;

    void Start () {
        cachedTransform = transform.parent.transform; 
        startingPos = cachedTransform.position;

    }

    void Update () {
    }
    void OnTouchDown()
    {
        deltaPosition = Input.GetTouch(0).deltaPosition;
        initialPosition = cachedTransform.position;
    }

    void OnTouchStay()
    {
        time += Time.deltaTime;
        deltaPosition = Input.GetTouch(0).deltaPosition;
        bool isIdle = (Mathf.Abs(initialPosition.x - cachedTransform.position.x) < 5 && Mathf.Abs(initialPosition.y - cachedTransform.position.y) < 5);
/*        if (time > 0.3 && time < 1.2 && isIdle)
        {
            GameObject.Find("favorite (1)").GetComponent<Animator>().enabled = true;
            GameObject.Find("favorite (1)").GetComponent<Animator>().SetBool("replay", true);
        }*/
        if (time >= 0.8 && isIdle)
        {
            //GameObject.Find("favorite (1)").GetComponent<Animator>().SetBool("replay", false);
            GameObject.Find("mapInput").GetComponent<BoxCollider>().enabled = false;
        }
        if (time > 2 || time > 1 && (Mathf.Abs(initialPosition.x - cachedTransform.position.x) > 6 || Mathf.Abs(initialPosition.y - cachedTransform.position.y) > 6))
            time = -999;
        if (time > 0.05 || time < 0)
        {
            DragObj(deltaPosition);
        }
    }

    void OnTouchUp()
    {
        time = 0;
        GameObject.Find("mapInput").GetComponent<BoxCollider>().enabled = true;
    }

    void OnTouchExit()
    {
        time = 0;
        GameObject.Find("mapInput").GetComponent<BoxCollider>().enabled = true;
    }

    void DragObj (Vector2 deltaPos) {
        cachedTransform.position = new Vector3(Mathf.Clamp((deltaPos.x * dragSpeed) + cachedTransform.position.x, 
            startingPos.x - _horizontallimit, startingPos.x + _horizontallimit), 
            Mathf.Clamp((deltaPos.y * dragSpeed) + cachedTransform.position.y, 
            startingPos.y - _verticallimit, startingPos.y + _verticallimit), cachedTransform.position.z);
    }
}﻿