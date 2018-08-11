using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawning : MonoBehaviour {

    public float SpawnRate;
    private float lastSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /**if (Input.GetMouseButton(0))
        {
            mouseRay();
        }**/

	}

    private void FixedUpdate()//randomly get position and spawn wall there
    {
        if (Time.time-lastSpawn>SpawnRate)
        {
            Debug.Log("Casting");
                RaycastHit hit;
                if (Physics.Raycast(transform.position,Vector3.down, out hit, Mathf.Infinity)){
                    if (hit.collider.tag == "Player" || hit.collider.tag == "Ground")
                    {
                        Debug.Log("Success");
                        //break;
                    }
                }



            lastSpawn = Time.time;
        }
    }


    void mouseRay()
    {
        RaycastHit hitPoint;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity))
        {
            Debug.Log(hitPoint.collider.tag);
        }
    }

}
