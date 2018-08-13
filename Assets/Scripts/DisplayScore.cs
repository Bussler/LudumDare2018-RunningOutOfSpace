using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayScore : MonoBehaviour {

    Text scoreText;

    private int lastScore;
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
	    scoreText.text = "Score: " + MyGameManager.score;
	    lastScore = MyGameManager.score;
	}

    private void Update() {
        if (MyGameManager.score != lastScore) {
            scoreText = GetComponent<Text>();
            scoreText.text = "Score: " + MyGameManager.score;
            lastScore = MyGameManager.score;
        }
    }
}
