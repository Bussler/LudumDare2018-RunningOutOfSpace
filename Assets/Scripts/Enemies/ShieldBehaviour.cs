using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {

    public bool canRotate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canRotate)
        {
            rotateAroundObject();
        }
	}

    private void rotateAroundObject()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="PlayerShot")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "PlayerRocket")
        {
            int cDmg = other.GetComponent<PProjectile>().dmg/3;
            transform.parent.GetComponent<EnemyHandle>().e_health -= cDmg;
            Destroy(other.gameObject);
        }
        
    }

}
