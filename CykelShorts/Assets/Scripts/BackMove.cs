using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMove : MonoBehaviour {
    public GameObject Player;
    public GameObject OtherBack;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.x >= transform.position.x -5 && Player.transform.position.x <= transform.position.x + 5)
        {

            OtherBack.transform.position = new Vector2(transform.position.x + 25, OtherBack.transform.position.y);
        }
	}
}
