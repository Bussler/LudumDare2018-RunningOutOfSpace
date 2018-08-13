using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandle : MonoBehaviour {

    public int e_health;
    public int givenScore;

    public ParticleSystem explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (e_health<=0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            destroy();
        }
	}

    private void OnDestroy()
    {
        Debug.Log(MyGameManager.score);
        MyGameManager.score += givenScore;
        MyGameManager.lastDeath = Time.time;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

}
