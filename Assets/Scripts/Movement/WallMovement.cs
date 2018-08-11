using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {

    private bool onGround=false;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (onGround == false)
        {
            float amtToMove = speed * Time.deltaTime;
            transform.Translate(Vector3.down * amtToMove);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            onGround = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        if (onGround==false&&collision.collider.tag=="Player")
        {
            //do damage here
            Destroy(gameObject);
        }
    }
}
