using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    public List<GameObject> enemies;
    public float spawnRate;
    float lastSpawn;
    bool onceerhoet = false;

    float lastScore = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time-lastSpawn>spawnRate)
        {
            SpawnEnemy();
        }

        if (MyGameManager.level==0&&onceerhoet==false&&MyGameManager.score>=1100)
        {
            spawnRate = spawnRate * 0.8f;
            onceerhoet = true;
        }

        if (MyGameManager.level==3&&MyGameManager.score>lastScore+400)
        {
            spawnRate = spawnRate * 0.9f;//TODO vlt anpassen
            lastScore = MyGameManager.score;
        }

	}


    void SpawnEnemy()
    {
        //get random position
        for (int i=0;i<10;i++)
        {
            int randX = (int)Random.Range(-14, 14);
            int randZ = (int)Random.Range(-14, 14);
            gameObject.transform.position = new Vector3(randX, transform.position.y, randZ);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Ground")//enemies nur auf ground level spawnen
                {
                    Debug.Log(randX+" "+randZ);
                    spawnRandom(randX,randZ);
                    break;
                }
            }

        }

        lastSpawn = Time.time;
    }

    void spawnRandom(int x, int z)
    {
        //get a random enemy
        int rand = (int)Random.Range(0, enemies.Count);

        GameObject randObj = enemies[rand];

        int randRot = (int)Random.Range(0, 360);
        int randa= (int)Random.Range(0, 2);
        int randb= (int)Random.Range(0, 2);
        int randc = (int)Random.Range(0, 2);

        //randObj.transform.rotation = Quaternion.Euler(0, randRot, 0);

        if (rand==0)//simple turret
        {
            SimpleEnemyBehaviour behav = randObj.GetComponent<SimpleEnemyBehaviour>();
            if (randa==1)
            {
                behav.shoot1 = true;
            }
            else
            {
                behav.shoot2 = true;
                behav.shoot1 = false;
            }

            if (randb==1)
            {
                behav.lookAt = true;
            }
            else
            {
                behav.lookAt = false;
            }

            if (randc == 1)
            {
                behav.hasShield = true;
            }
            else
            {
                behav.hasShield = false;
            }
        }

        if (rand == 1)//simple ufo
        {
            SimpleEnemyBehaviour behav = randObj.GetComponent<SimpleEnemyBehaviour>();
            if (randa == 1)
            {
                behav.shoot1 = false;
                behav.shootmultipleDiamond = true;
            }
            else
            {
                behav.shoot1 = false;
                behav.shootmultipleDiamond = false;
                behav.shootMultipleCross = true;
            }

            if (randb == 1)
            {
                behav.lookAt = true;
            }
            else
            {
                behav.lookAt = false;
            }

            if (randc == 1)
            {
                behav.hasShield = true;
            }
            else
            {
                behav.hasShield = false;
            }

        }

        if (rand==2)//moving enemy
        {
            if (randa==1)
            {
                randObj.GetComponent<MovingEnemy>().hasfrontShield=true;
            }
            else
            {
                randObj.GetComponent<MovingEnemy>().hasfrontShield = false;
            }
        }


        Instantiate(randObj, new Vector3(x,1,z), Quaternion.Euler(0, randRot, 0));
    }

}
