using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovementStartMenu : MonoBehaviour {

    private float speed;

    void Start() {
        speed = (float)Random.Range(700, 1800)/100f;
    }
    
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x - (speed*Time.deltaTime), transform.position.y - (speed*Time.deltaTime), transform.position.z);
	    if (transform.position.y < -100) {
	        Destroy(gameObject);
	    }
	}
}
