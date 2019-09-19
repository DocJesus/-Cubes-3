using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    Text scoreText;
    public static int score;

	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score:\n" + score;
	}
}
