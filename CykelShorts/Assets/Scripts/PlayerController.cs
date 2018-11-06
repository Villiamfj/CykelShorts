using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb2d;
    public float JumpHeight;
    bool isGrounded;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		//jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (rb2d.velocity.y == 0)
            //{
            //    isGrounded = true;
            //}
            if (isGrounded)
            {
                rb2d.AddForce(new Vector2(0, JumpHeight));
                isGrounded = false;
            }
            
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }

        //Enemy Collision
        if(collision.gameObject.tag == "Obstacle")
        {
            //GameOver
            //insæt gameOver her
            Debug.Log("GameOver");
        }
    }
}
