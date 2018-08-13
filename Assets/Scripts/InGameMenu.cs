using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {
    private bool isOn = false;

    public List<Button> buttons;
    public GameObject dunkel;

    public Slider music;
    public Text musicVol;
    public AudioSource musikSource;
    private float musicVolStart;

    public Canvas canvas;
	// Use this for initialization
	void Start () {
	    musicVolStart = musikSource.volume;
	    releaseMenu();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape)) {
	        if (isOn) {
	            isOn = false;
	            Time.timeScale = 1;
	            releaseMenu();
	        } else {
	            isOn = true;
	            Time.timeScale = 0;
	            displayMenu();
	        }
	    }
        if (musikSource!=null)
        {
            musikSource.volume = musicVolStart * music.value;
        } 
	    
	}
    void resetBox() {
        for (int i = 0; i < buttons.Count; i++) {
            buttons[i].GetComponent<Mousew>().resetBox();
        }   
    }
    void displayMenu() {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        music.gameObject.SetActive(false);
        musicVol.gameObject.SetActive(false);
        dunkel.gameObject.SetActive(true);
        for (int i = 0; i < buttons.Count-1; i++) {
            buttons[i].gameObject.SetActive(true);
        }
        
    }

    public void optionsPressed() {
        for(int i = 0; i < buttons.Count-1; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        buttons[3].gameObject.SetActive(true);
        
        music.gameObject.SetActive(true);
        musicVol.gameObject.SetActive(true);
        resetBox();
    }

    public void continuePressed() {
        releaseMenu();
        Time.timeScale = 1;
        resetBox();
    }

    public void backToMenuPressed() {
        resetBox();
        Destroy(canvas.gameObject);
        Time.timeScale = 1;

        MyGameManager.score = 0;
        MyGameManager.p_health = 5;
        SceneManager.LoadScene(0);
        
    }

    public void backPressed() {
        resetBox();
        displayMenu();
    }
    
    public void releaseMenu() {
        dunkel.gameObject.SetActive(false);
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        music.gameObject.SetActive(false);
        musicVol.gameObject.SetActive(false);
    }
}
