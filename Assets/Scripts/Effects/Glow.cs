using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour {
    private bool up = false;
    private Color actualColor;
    public Color destColor;

    private Color startColor;

    public float ColorDifference = 1.5f;
    
   
    
    private Material a;
	// Use this for initialization
	void Start () {
	    a = GetComponent<Renderer>().material;
	    actualColor = a.GetColor("_EmissiveColor");
	    startColor = a.GetColor("_EmissiveColor");
	    destColor = startColor;
	    destColor.r -= 20f;
	    destColor.g -= 20f;
	    destColor.b -= 20f;
	}
    
	// Update is called once per frame
	void Update () {
	   // Debug.Log(up);
	    if (up) {
	        actualColor.r += ColorDifference*Time.deltaTime;
	        actualColor.g += ColorDifference*Time.deltaTime;
	        actualColor.b += ColorDifference*Time.deltaTime;
	        a.SetColor("_EmissiveColor", actualColor);
	        if (actualColor.r > startColor.r) {
	            up = false;
	        }
	        
	    } else {
	       // Debug.Log(actualColor);
	        actualColor.r -= ColorDifference*Time.deltaTime;
	        actualColor.g -= ColorDifference*Time.deltaTime;
	        actualColor.b -= ColorDifference * Time.deltaTime;
	        a.SetColor("_EmissiveColor", actualColor);
	        if (actualColor.r < 0 && actualColor.g < 0 && actualColor.b < 0) {
	            up = true;
	        }
	        
	    }
	}
}
