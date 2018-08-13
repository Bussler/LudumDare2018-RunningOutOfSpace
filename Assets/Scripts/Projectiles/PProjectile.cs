using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PProjectile : MonoBehaviour {

    public float speed;
    public int dmg;
   
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        float amtToMove = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amtToMove);

        if (!transform.GetChild(0).GetComponent<Renderer>().isVisible)
        {
            destroy();
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        destroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Boundary")
        {
            destroy();
        }

        if (other.tag=="EnemyDestroyShot"&&gameObject.tag=="PlayerShot")
        {
            other.gameObject.GetComponent<EProjectile>().destroy();
        }

        if (other.tag=="Enemy")
        {
            //Debug.Log("Hit");
            other.gameObject.GetComponent<EnemyHandle>().e_health -= dmg;
            destroy();
        }

    }

}
