using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteroitenSpawn : MonoBehaviour {
    
    public List<GameObject> meteoriten;

    private int counter = 100;
    
	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
	    counter--;
	    if (counter <= 0) {
	        int meteroitenNr = Random.Range(0, 4);
	        //float randomwinkel = (Random.RandomRange(-100, 100)/10f);
	        float xOffset = Random.Range(-20, 35);
	        Instantiate(meteoriten[meteroitenNr], new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), Quaternion.identity );
	        counter = Random.Range(100, 250);
	        Debug.Log("meteroit " + meteoriten[meteroitenNr].name + "an pos " + xOffset);
	    }
	    
	}
}
