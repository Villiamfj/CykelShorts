using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
    public float Time;
    GameObject player;
	// Use this for initialization
	void Start () {
        //Destroy(gameObject, Time);
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x -5>= transform.position.x)
        {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
