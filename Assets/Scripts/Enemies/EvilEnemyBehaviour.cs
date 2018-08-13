using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEnemyBehaviour : MonoBehaviour {

    public int dmgHug;
    bool isAttacking=true;
    float lastTimeAttacked;
    float recoverAttack=2;
    bool isMoving = false;

    public float speed = 3f;

    float rX;
    float rZ;

    Vector3 targetPos;
	
	// Update is called once per frame
	void Update () {

        if (!isAttacking)
        {
            if (Time.time-lastTimeAttacked>recoverAttack)
            {
                isAttacking = true;
            }
        }

        if (isMoving==false)
        {
            moveRandom();
        }

        if (Mathf.Abs(transform.position.x-rX) <= 0.3 &&Mathf.Abs( transform.position.z-rZ )<=0.3)
        {
            StartCoroutine("freeze");
        }

        //Vector3 movement = new Vector3(rX - transform.position.x, 0.0f, rZ - transform.position.z)*speed*Time.deltaTime;
        //transform.Translate(movement);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

    IEnumerator freeze()
    {
        yield return new WaitForSeconds(2);
        isMoving = false;
        yield return null;
    }

    void moveRandom()
    {
        isMoving = true;

        rX = Random.Range(-9, 9);//get a random spot
        rZ = Random.Range(-9, 9);

        targetPos = new Vector3(rX, transform.position.y, rZ);
        
       // Vector3 movement = new Vector3(rX-transform.position.x, 0.0f, rZ-transform.position.z);
       // gameObject.GetComponent<Rigidbody>().velocity = movement; //TODO move to spot
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&&isAttacking==true) {
            isMoving = false;
            isAttacking = false;
            lastTimeAttacked = Time.deltaTime;

            if (MyGameManager.isAttackable)
            {
                MyGameManager.p_health -= dmgHug;
                MyGameManager.isAttackable = false;
                MyGameManager.lastHit = Time.time;
            }
            
        }

        if (other.tag=="Boundary")
        {
            isMoving = false;
        }

    }

}
