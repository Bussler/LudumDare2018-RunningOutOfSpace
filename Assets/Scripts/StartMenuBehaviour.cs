using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuBehaviour : MonoBehaviour {
    
    public List<Button> buttons;
    public Slider musicSlider;
    public AudioSource musik;
    private float musicVolume;

    public InputField namensEingabe;
    
    private void Awake() {
        musicVolume = musik.volume;
    }


    public Text musiktext;
	// Use this for initialization
	void Start () {
	    for (int i = 0; i < buttons.Count; i++) {
	        if (i < 3) {
	            buttons[i].gameObject.SetActive(true);
	        } else {
	            buttons[i].gameObject.SetActive(false);
	        }
	    }
	    musicSlider.gameObject.SetActive(false);
        namensEingabe.gameObject.SetActive(false);
	    musiktext.gameObject.SetActive(false);
	    
	}



    public void playPressed() {
        for (int i = 0; i < 3; i++) {
            buttons[i].gameObject.SetActive(false);
        }
        buttons[4].gameObject.SetActive(true);
        
        buttons[3].gameObject.SetActive(true);
        
        buttons[5].gameObject.SetActive(true);
        buttons[6].gameObject.SetActive(true);
        resetBox();
    }
    void resetBox() {
        for (int i = 0; i < buttons.Count; i++) {
            buttons[i].GetComponent<Mousew>().resetBox();
        }   
    }

    public void huntScorePresses() {
        for (int i = 0; i < buttons.Count; i++) {
            buttons[i].gameObject.SetActive(false);
        }
        namensEingabe.gameObject.SetActive(true);
        buttons[buttons.Count-1].gameObject.SetActive(true);
    }

    public void endlessPlayPressed() {

        //speicher namen
        if (namensEingabe.text == "")
        {
            Highscores.UserName = "Anonymous Owl";
        }
        else
        {
            Highscores.UserName = namensEingabe.text;
        }

        SceneManager.LoadScene(4);
    }

    public void skipTutorialPressed() {
        SceneManager.LoadScene(3);
    }

    public void playTutorialPressed() {
        SceneManager.LoadScene(2);
    }
    
    public void quitPressed() {
        Application.Quit();
    }
	
    public void optionsPressed() {
        for (int i = 0; i < 3; i++) {
            buttons[i].gameObject.SetActive(false);
        }
        buttons[5].gameObject.SetActive(true);

        musicSlider.gameObject.SetActive(true);

        musiktext.gameObject.SetActive(true);
        resetBox();
    }

    public void backPressed() {
        Start();
        resetBox();
    }

    void Update() {
        musik.volume = musicVolume * musicSlider.GetComponent<Slider>().value;
    }
    
}
