using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour {
    float speed;
    public float height;
    Rigidbody2D rb2d;
    public float EksSpeed;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (height != 0)
        {
            transform.position = new Vector2(transform.position.x, height);
        }
        if ( speed == 0) { EksSpeed = 0; }
            rb2d.velocity = new Vector2(-PlayerController.reference.speed - EksSpeed, 0);

    }
}
