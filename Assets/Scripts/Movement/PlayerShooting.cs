using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    // speed is the rate at which the object will rotate
    public float speed;
    float lastTimeFired;

    public enum Weapon
    {
        Laser,
        Rocket
    };

    public Weapon komisch = Weapon.Laser;//blame luca
    int currWeap = 0;
    float firerate = 0.3f;

    public List<GameObject> Projectiles;//store the instantiated projectiles


    private void Update()
    {
        if (Input.GetMouseButton(0)&&Time.time-lastTimeFired>firerate)//shooting
        {
            Vector3 spawnPos = transform.GetChild(0).position;
            Instantiate(Projectiles[currWeap], spawnPos, transform.rotation * Quaternion.Euler(0, 180, 0));

            lastTimeFired = Time.time;
        }

        if (Input.GetMouseButtonDown(1))//changing weapons
        {   //determine which weapon to use
            currWeap = (currWeap+1) % 2; //TODO später mehrere waffen freischalten
            Debug.Log(currWeap);

            switch (currWeap)
            {
                case 0: komisch = Weapon.Laser;
                        firerate = 0.3f;
                    break;

                case 1: komisch = Weapon.Rocket;
                        firerate = 1f;
                    break;

                default: break;
            }
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
