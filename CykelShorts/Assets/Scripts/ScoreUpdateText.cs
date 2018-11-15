using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdateText : MonoBehaviour {
    public Text ScoreText;
    public bool ShowMultiplier;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (ShowMultiplier)
        {
            ScoreText.text = "" + PlayerController.reference.Score + "x" + PlayerController.reference.ScoreMultiplier;
        }
        else
        {
            ScoreText.text = "Score: " + PlayerController.reference.Score;
        }
    }
}
