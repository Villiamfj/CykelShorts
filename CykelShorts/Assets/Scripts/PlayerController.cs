﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb2d;
    public float JumpHeight;
    bool isGrounded;
    Animator Anim;
    CircleCollider2D Ccol;
    public float speed;
    float startSpeed;
    public float multiplier;
    static public PlayerController reference;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
        Anim = GetComponent<Animator>();
        Ccol = GetComponent<CircleCollider2D>();
        reference = this;
        startSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
        //speed ramping
        speed = speed *(1 + multiplier/100);

		//jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            //if (rb2d.velocity.y == 0)
            //{
            //    isGrounded = true;
            //}
            if (isGrounded)
            {
                Anim.SetInteger("state", 2);
                rb2d.AddForce(new Vector2(0, JumpHeight));
                isGrounded = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space)|| Input.GetKeyUp(KeyCode.W))
        {
            Anim.SetInteger("state", 0);
        }

        //duk
        if (Input.GetKeyDown(KeyCode.S))
        {
            //insæt duk her
            Anim.SetInteger("state", 1);
            Ccol.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Anim.SetInteger("state", 0);
            Ccol.enabled = true;
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
            speed = startSpeed;
            //GameOver
            //insæt gameOver her
            Debug.Log("GameOver");
        }
    }
}
