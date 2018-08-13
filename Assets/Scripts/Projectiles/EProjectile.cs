using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectile : MonoBehaviour {

    public float speed;
    public int dmg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amtToMove);

        if(!GetComponent<Renderer>().isVisible)
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
        if (other.tag == "Boundary")
        {
            destroy();
        }

        if (other.tag == "Player")
        {

            if (MyGameManager.isAttackable)
            {
                MyGameManager.p_health -= dmg;
                MyGameManager.isAttackable = false;
                MyGameManager.lastHit = Time.time;
            }
            
            destroy();
        }

    }
}
