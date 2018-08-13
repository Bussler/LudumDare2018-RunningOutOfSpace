using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StartMenuShipMovement : MonoBehaviour {

    public float speed = 1f;
    private bool gerade = false;
    private bool up = false;
    private float topY = 0.1f;
    private float start;
    private float bottomY = 0.1f;

    private Transform s;
    private int counter = 0;

    // Use this for initialization
    void Start() {
        start = transform.position.y;
        s = transform;
    }

    // Update is called once per frame
    void Update() {
        counter++;
       // Debug.Log(up);
        if (counter < 1000) {
            if (up) {
                transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x,
                        start + topY, transform.position.z), 0.7f * Time.deltaTime);

                if (transform.position.y >= start + topY - 0.05f) {
                    up = false;
                }
            } else {
                transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x,
                        start - topY, transform.position.z), 0.7f * Time.deltaTime);

                if (transform.position.y <= start - bottomY + 0.05f) {
                    up = true;
                }
            }
        } else {
            transform.Rotate(new Vector3(0, 0, 1), 10 *Time.deltaTime * 30, Space.Self);
            if (transform.localEulerAngles.z > -4f && transform.localEulerAngles.z < 4f) {
                counter = 0;
            }
        }
    }
}