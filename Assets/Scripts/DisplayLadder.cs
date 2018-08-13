using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DisplayLadder : MonoBehaviour {

    public Text[] highscoreText;
    Highscores highscoreManager;

	// Use this for initialization
	void Start () {

        for (int i=0;i<highscoreText.Length;i++)
        {
            highscoreText[i].text = i + 1 + ". Fetching... ";
        }

        highscoreManager = GameObject.Find("Highscores").GetComponent<Highscores>();

        StartCoroutine("RefreshHighscores");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnHighscoresDownloaded(Highscore[] hList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if (hList.Length>i)
            {
                highscoreText[i].text += hList[i].username + " - " + hList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while (SceneManager.GetActiveScene().name=="Startmenu")
        {
            highscoreManager.Downloadighscores();
            yield return new WaitForSeconds(30);
        }
    }

}
