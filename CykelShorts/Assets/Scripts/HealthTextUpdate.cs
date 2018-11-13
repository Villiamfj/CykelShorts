using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextUpdate : MonoBehaviour {
    public Text Htext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerController.reference.Health == 3)
        {
            Htext.text = "❤❤❤";
        }
        else if (PlayerController.reference.Health == 2)
        {
            Htext.text = "❤❤";
        }
        else if (PlayerController.reference.Health == 1)
        {
            Htext.text = "❤";
        }
        else
        {
            Htext.text = ":(";
        }

	}
}
