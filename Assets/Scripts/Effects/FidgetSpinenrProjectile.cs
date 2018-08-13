using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FidgetSpinenrProjectile : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y * 1* speed * Time.deltaTime, transform.rotation.z);
	}
}
