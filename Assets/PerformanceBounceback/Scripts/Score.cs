using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameManager gameManager;

    private Text scoreText;
    private int displayedScore = -1;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (displayedScore!= gameManager.score)
        {
            scoreText.text = "Score: " + gameManager.score.ToString();
            displayedScore = gameManager.score;
        }
		
	}
}
