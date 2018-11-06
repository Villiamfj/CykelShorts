using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
    public float Time;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, Time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
