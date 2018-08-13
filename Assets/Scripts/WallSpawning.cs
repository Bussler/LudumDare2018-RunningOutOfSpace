using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawning : MonoBehaviour {

    public float SpawnRate;
    private float lastSpawn;
    public GameObject wall;

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
        if (Time.time-lastSpawn>SpawnRate&&(MyGameManager.level==0||MyGameManager.level==3))
        {
            StartCoroutine("SearchPos");
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

    IEnumerator SearchPos()
    {
       for(int i=0;i<5;i++)
        {
            int randX=(int)Random.Range(-13,13);
            int randZ=(int)Random.Range(-13,13);
            gameObject.transform.position = new Vector3(randX, transform.position.y, randZ);

           // Debug.Log("Casting");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Player" || hit.collider.tag == "Ground")
                {
                    //Debug.Log("Success");
                    Instantiate(wall, transform.GetChild(0).position, Quaternion.identity);
                    break;
                }
            }
        }
        lastSpawn = Time.time;
        yield return null;
    }

}
