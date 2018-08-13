using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public List<GameObject> enemies;
    bool[] ticked = new bool[7];

    float timeBetweenSpawns=2;

	
	// Update is called once per frame
	void FixedUpdate () {
        int score = MyGameManager.score;

        if (Time.time - MyGameManager.lastDeath > timeBetweenSpawns)
        {

            if (score == 100)
            {
                if (!ticked[0])
                {
                    ticked[0] = true;
                    enemies[0].SetActive(true);
                    enemies[1].SetActive(true);

                }
            }

            if (score == 200)
            {
                if (!ticked[1])
                {
                    ticked[1] = true;
                    enemies[2].SetActive(true);
                    enemies[3].SetActive(true);

                }
            }

            if (score == 300)
            {
                if (!ticked[2])
                {
                    ticked[2] = true;
                    enemies[4].SetActive(true);
                    enemies[5].SetActive(true);

                }
            }

            if (score == 400)
            {
                if (!ticked[3])
                {
                    ticked[3] = true;
                    enemies[6].SetActive(true);
                    enemies[7].SetActive(true);

                }
            }

            if (score == 500)
            {
                if (!ticked[4])
                {
                    ticked[4] = true;
                    
                    if (GameObject.Find("PlayerShip").transform.position.z>0)
                    {
                        enemies[8].transform.position = new Vector3(enemies[8].transform.position.x, enemies[8].transform.position.y, -8);
                        enemies[8].transform.rotation = Quaternion.Euler(0, 0, 0);
                        enemies[9].transform.position = new Vector3(enemies[9].transform.position.x, enemies[9].transform.position.y, -8);
                        enemies[9].transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    enemies[8].SetActive(true);
                    enemies[9].SetActive(true);

                }
            }

            if (score == 600)
            {
                if (!ticked[5])
                {
                    ticked[5] = true;
                    enemies[10].SetActive(true);

                }
            }

            if (score == 700)
            {
                if (!ticked[6])
                {
                    ticked[6] = true;
                    MyGameManager.score += 100;
                   // Debug.Log(MyGameManager.score);
                }
            }

        }

	}
    
}
