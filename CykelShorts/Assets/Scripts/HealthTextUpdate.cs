using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextUpdate : MonoBehaviour {
    public Text Htext;
    public Sprite[] HealthPictures = new Sprite[4];
    Image kage;
	// Use this for initialization
	void Start () {
        kage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerController.reference.Health == 3)
        {
            kage.sprite = HealthPictures[3];
            
            //Htext.text = "❤❤❤";
        }
        else if (PlayerController.reference.Health == 2)
        {
            kage.sprite = HealthPictures[2];
            //Htext.text = "❤❤";
        }
        else if (PlayerController.reference.Health == 1)
        {
            kage.sprite = HealthPictures[1];
            //Htext.text = "❤";
        }
        else
        {
            kage.sprite = HealthPictures[0];
            //Htext.text = ":(";
        }

	}
}
