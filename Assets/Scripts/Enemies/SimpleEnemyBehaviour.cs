using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehaviour : MonoBehaviour {

    public float fireRate;
    private float lastFire;
    public GameObject projectile1;
    public GameObject projectile2;

    public bool shoot1;
    public bool shoot2;
    public bool shootMultipleCross;
    public bool shootmultipleDiamond;
    public bool lookAt;
    public bool hasShield;

    private bool destroyshot = false;

    private void Start()
    {
        if (hasShield)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {

        if (lookAt)
        {
            lookAtPlayer();
        }

        if (Time.time-lastFire>fireRate)
        {
            GameObject projectile = null;//projectile1;
            if (!destroyshot)
            {
                projectile = projectile2;
                destroyshot = true;
            }
            else
            {
                projectile = projectile1;
                destroyshot = false;
            }

            if (shoot1==true)
            {
                Instantiate(projectile1, transform.position, transform.rotation);
            }
            else
            {
                if (shoot2 == true)
                {
                    Instantiate(projectile, transform.position, transform.rotation);
                }
                else
                {
                    if (shootMultipleCross==true)
                    {
                        Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0,45,0));
                        Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 135, 0));
                        Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0,225, 0));
                        Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 315, 0));
                    }
                    else
                    {
                        if (shootmultipleDiamond==true)
                        {
                            Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 0, 0));
                            Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                            Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 180, 0));
                            Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 270, 0));
                        }
                    }
                }
            }
            lastFire = Time.time;
        }
	}

   void lookAtPlayer()
    {
        GameObject player = GameObject.Find("PlayerShip");
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x - transform.position.x,0.0f,player.transform.position.z-transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
    }

}
