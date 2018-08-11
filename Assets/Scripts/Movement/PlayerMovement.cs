using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float PlayerSpeed;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //move the player
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed;
        float amtToMoveUP = Input.GetAxis("Vertical") * PlayerSpeed;
        //transform.Translate(Vector3.right * amtToMove); //Space.World wichtig für die rotation
        //transform.Translate(Vector3.forward * amtToMoveUP);
        Vector3 movement = new Vector3(amtToMove, 0.0f, amtToMoveUP);
        gameObject.GetComponent<Rigidbody>().velocity = movement;
       
    }
}
