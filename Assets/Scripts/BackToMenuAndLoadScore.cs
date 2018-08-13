using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToMenuAndLoadScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadAndScore()
    {
        if (MyGameManager.level == 3) {
            Highscores.AddNewHighscore(Highscores.UserName, MyGameManager.score);

        }

        MyGameManager.p_health = 5;
        MyGameManager.score = 0;
        
        SceneManager.LoadScene(0);
    }

}
