using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public int dmg;
    GameObject player;

    public bool hasfrontShield;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerShip");
        if (hasfrontShield)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            turnSpeed = 1;
            speed = speed / 2;
        }
	}
	
	// Update is called once per frame
	void Update () {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        float amtToMove = speed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * amtToMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            if (MyGameManager.isAttackable)
            {
                MyGameManager.p_health -= dmg;
                MyGameManager.isAttackable = false;
                MyGameManager.lastHit = Time.time;
            }

            //gameObject.GetComponent<EnemyHandle>().destroy();
            Destroy(gameObject);
        }

        if (other.tag=="Boundary")
        {
            //gameObject.GetComponent<EnemyHandle>().destroy();
            Destroy(gameObject);//Todo soll man dafür auch punkte für den score bekommen?
        }
    }

}
