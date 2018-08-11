using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PProjectile : MonoBehaviour {

    public float speed;
   
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        float amtToMove = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amtToMove);
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Boundary")
        {
            destroy();
        }

        if (other.tag=="EnemyDestroyShot")
        {
            //destroy other shot
        }

        if (other.tag=="Enemy")
        {

        }

    }

}
