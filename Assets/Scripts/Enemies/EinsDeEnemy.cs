using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsDeEnemy : MonoBehaviour {

    public List<GameObject> enemies;
    bool[] ticked = new bool[6];

    float timeBetweenSpawns = 2;

    float anfangsscore;
    bool start = false;
    float startzeit;

    private void Awake()
    {
        anfangsscore = MyGameManager.score;
        startzeit = Time.time;
    }

    // Update is called once per frame
    void Update () {

        int score = MyGameManager.score;

        if (score==anfangsscore&&start==false)
        {
            if (Time.time-startzeit>timeBetweenSpawns)
            {
                start = true;
            }
        }
        else
        {
            if (Time.time-MyGameManager.lastDeath>timeBetweenSpawns)//spawning waves
            {
                if (score==anfangsscore)
                {
                    if (!ticked[0])
                    {
                        enemies[0].SetActive(true);
                        enemies[1].SetActive(true);
                        enemies[2].SetActive(true);

                        ticked[0] = true;
                    }
                }

                if (score == anfangsscore + 100)
                {
                    if (!ticked[1])
                    {
                        enemies[3].SetActive(true);
                        enemies[4].SetActive(true);

                        ticked[1] = true;
                    }
                }

                if (score == anfangsscore + 200)
                {
                    if (!ticked[2])
                    {
                        enemies[5].SetActive(true);
                        enemies[6].SetActive(true);
                        enemies[7].SetActive(true);

                        ticked[2] = true;
                    }
                }

                if (score == anfangsscore + 300)
                {
                    if (!ticked[3])
                    {
                        enemies[8].SetActive(true);
                        enemies[9].SetActive(true);

                        ticked[3] = true;
                    }
                }

                if (score == anfangsscore + 400)
                {
                    if (!ticked[4])
                    {
                        enemies[10].SetActive(true);
                        enemies[11].SetActive(true);
                        enemies[12].SetActive(true);

                        ticked[4] = true;
                    }
                }

                if (score == anfangsscore + 500)
                {
                    if (!ticked[5])
                    {
                        enemies[13].SetActive(true);
                        enemies[14].SetActive(true);
                        enemies[15].SetActive(true);
                        enemies[16].SetActive(true);

                        ticked[5] = true;
                    }
                }

            }
        }

	}
}
