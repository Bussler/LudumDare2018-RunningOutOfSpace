using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour {

    private int random = 0;//0:bomb, 1:laser

    private void Awake()
    {
       random = (int)Random.Range(0, 2);
        
    }

    private void OnDestroy()
    {
        if (random == 1)
        {
            Debug.Log("Laser");
            MyGameManager.laserSeconds += 5;
        }
        else
        {
            Debug.Log("Bomb");
            MyGameManager.bombCount += 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Destroy(gameObject);
        }
    }

}
