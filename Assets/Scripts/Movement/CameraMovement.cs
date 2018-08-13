using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject spaceship;
    public float Smoothspeed=0.125f;
    public bool follow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (follow)
        {
            Vector3 dpos = new Vector3(spaceship.transform.position.x, transform.position.y, spaceship.transform.position.z);
            Vector3 smoothPos = Vector3.Lerp(transform.position, dpos, Smoothspeed);

            transform.position = smoothPos;
        }
    }
}
