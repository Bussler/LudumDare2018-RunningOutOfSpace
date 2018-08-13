using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRadius : MonoBehaviour {

    public bool radius;


    private void OnTriggerStay(Collider other)//called for each element inside trigger
    {
        if (Input.GetKeyDown(KeyCode.Space)&&radius)
        {
            if (other.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHandle>().e_health -= transform.parent.GetComponent<BombBehaviour>().dmg;
                if (!transform.parent.GetComponent<BombBehaviour>().detonated)
                {
                    transform.parent.GetComponent<BombBehaviour>().detonated = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.tag == "Boundary"&&!radius)
            {
                Destroy(transform.parent.gameObject);
            }

        
    }

}
