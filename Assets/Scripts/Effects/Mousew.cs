using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mousew : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Color onhoverColor;
    public Color onexitColor;

    public Sprite umrandung;
    private Sprite standard;
    
    
    public GUISkin skins;
	// Use this for initialization
	void Start () {
	    standard = this.GetComponent<Button>().image.sprite;
	}
	

    public bool isOver = false;

       public void OnPointerEnter(PointerEventData eventData)
        {
        Debug.Log("Mouse enter");
            this.GetComponent<Button>().image.sprite = umrandung;
            this.GetComponent<Button>().image.color = Color.white;
        isOver = true;
        }



    public void OnPointerExit(PointerEventData eventData) {
       resetBox();
    }

    public void resetBox() {
        this.GetComponent<Button>().image.sprite = standard;
        this.GetComponent<Button>().image.color = new Color(0, 0, 0, 0); 
    }
   
	}

  

