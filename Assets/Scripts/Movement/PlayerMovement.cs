using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float PlayerSpeed;
    bool isBlinking = false;

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

        if (MyGameManager.isAttackable==false&&isBlinking==false)
        {
            isBlinking = true;
            StartCoroutine("blink");
        }

        if (MyGameManager.level==1)
        {
            boundaries();
        }
       
    }

    void boundaries()
    {
        if (transform.position.x<=-13)
        {
            transform.position = new Vector3(-13, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 13)
        {
            transform.position = new Vector3(13, transform.position.y, transform.position.z);
        }

        if (transform.position.z >= -7)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -7);
        }
        if (transform.position.z <= -8.3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -8.3f);
        }
    }

    bool istrue()
    {
        return MyGameManager.isAttackable;
    }

    IEnumerator blink()
    {

        GameObject ship = transform.GetChild(1).gameObject;

        Color color = ship.GetComponent<Renderer>().material.GetColor("_BaseColor");
        color.a = 0.3f;
        ship.GetComponent<Renderer>().material.SetColor("_BaseColor", color);

        yield return new WaitUntil(istrue);
        
        color.a = 1f;
        ship.GetComponent<Renderer>().material.SetColor("_BaseColor", color);

        isBlinking = false;
        yield return null;
    }

}
