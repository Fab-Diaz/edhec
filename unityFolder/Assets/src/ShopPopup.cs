using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPopup : MonoBehaviour {

    private float scaleX;
    private float scaleY;
    private float scaleZ;


    // Use this for initialization
    void Start () {
        scaleX = this.transform.localScale.x;
        scaleY = this.transform.localScale.y;
        scaleZ = this.transform.localScale.z;
    }

    // Update is called once per frame
    void Update () {
        float limitMaxX = GameObject.Find("Camera").transform.position.x + 60;
        float limitMaxY = GameObject.Find("Camera").transform.position.y + 110;
        float limitMinX = GameObject.Find("Camera").transform.position.x - 60;
        float limitMinY = GameObject.Find("Camera").transform.position.y - 110;

        int speed = 20;

        if ((this.transform.position.x < limitMaxX && this.transform.position.x > limitMinX)
            && (this.transform.position.y < limitMaxY && this.transform.position.y > limitMinY) 
            && this.transform.localScale.x <= scaleX)
        {
            this.transform.localScale = new Vector3(
                this.transform.localScale.x + (scaleX / speed),
                this.transform.localScale.y + (scaleY / speed),
                this.transform.localScale.z + (scaleZ / speed));
        }
        else if (((this.transform.position.x > limitMaxX || this.transform.position.x < limitMinX)
            || (this.transform.position.y > limitMaxY || this.transform.position.y < limitMinY))
            && this.transform.localScale.x > 0)
        {
            this.transform.localScale = new Vector3(
                this.transform.localScale.x - (scaleX / speed),
                this.transform.localScale.y - (scaleY / speed),
                this.transform.localScale.z - (scaleZ / speed));
            if (this.transform.localScale.x <= 0)
                this.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
