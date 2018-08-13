using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    // speed is the rate at which the object will rotate
    public float speed;
    float lastTimeFired;

    bool shootinglaser=false;
    float lastshotlaser;

    public AudioSource shot;
    public AudioClip clip;
    
    float lastClickTime = 0;
    float cathtime = 0.25f;

    
    public enum Weapon
    {
        Laser,
        Rocket
    };

    public Weapon komisch = Weapon.Laser;//blame luca
    int currWeap = 0;
    int currSpecialWep = 0;//0 bomb, 1:laser
    float firerate = 0.3f;

    public List<GameObject> Projectiles;//store the instantiated projectiles


    private void Update()
    {
        Vector3 spawnPos = transform.GetChild(0).position;

        if (Input.GetKeyDown(KeyCode.Space))//special weapon
        {
            if (currSpecialWep==0)
            {
                if(MyGameManager.bombCount>=1&&!MyGameManager.bombActive){
                    
                    Instantiate(Projectiles[2], spawnPos, transform.rotation * Quaternion.Euler(0, 180, 0));
                    MyGameManager.bombCount--;
                }
            }
            else
            {
                if (MyGameManager.laserSeconds>0&&!shootinglaser)
                {
                   // Debug.Log("Begin laser");
                    shootinglaser = true;
                }
            }
        }

        if (shootinglaser==true&&MyGameManager.laserSeconds>0)
        {
            MyGameManager.laserSeconds -= Time.deltaTime;
    
            if (Time.time-lastshotlaser>0.2) {
                shot.PlayOneShot(clip);
                // Assign the other clip and play it
                Instantiate(Projectiles[0], spawnPos, transform.rotation * Quaternion.Euler(0, 180+45, 0));
                Instantiate(Projectiles[0], spawnPos, transform.rotation * Quaternion.Euler(0, 180+315, 0));
                lastshotlaser = Time.time;
            }


            if (MyGameManager.laserSeconds<=0)
            {
                MyGameManager.laserSeconds = 0;
                shootinglaser = false;
            }
        }
        
            if (Input.GetMouseButton(0) && Time.time - lastTimeFired > firerate)//shooting
            {
                //debugging:always look at mouse
                //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector3 withoutY = new Vector3(mousePos.x, transform.position.y, mousePos.z);
                //transform.LookAt(withoutY); //lookat könnte falsch sein, da model ja verkehrt herum
                //transform.rotation = Quaternion.LookRotation(transform.position - withoutY); //lookat umgedreht

                //shooting
                
                Instantiate(Projectiles[currWeap], spawnPos, transform.rotation * Quaternion.Euler(0, 180, 0));

                lastTimeFired = Time.time;
            }
        

        if (Input.GetMouseButtonDown(1))//changing weapons
        {
            if (Time.time-lastClickTime<cathtime)
            {
                //double
                currSpecialWep = (currSpecialWep + 1) % 2;
            }
            else
            { //single
              //  Debug.Log("single");
                //determine which weapon to use
                currWeap = (currWeap + 1) % 2; //TODO später mehrere waffen freischalten
                                               // Debug.Log(currWeap);

                switch (currWeap)
                {
                    case 0:
                        komisch = Weapon.Laser;
                        firerate = 0.3f;
                        break;

                    case 1:
                        komisch = Weapon.Rocket;
                        firerate = 0.9f;
                        break;

                    default: break;
                }

            }
            lastClickTime = Time.time;
        }

    }

    void FixedUpdate()
    {
        
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * Quaternion.Euler(0, 180, 0), speed * Time.deltaTime);
        }
    }
}
