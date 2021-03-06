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
    public float Health;
    public float multiplier;
    public float Score;
    public float ScoreMultiplier;
    public float StartScoreMultiplier;
    public Object menu;
    public GameObject GAMEOVER;
    static public PlayerController reference;

    private float nextActionTime = 0.0f;
    private float NextMultiPlierTime = 10f;
    public float MultiplierPeriod = 10f;
    public float period = 0.1f;



    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
        Anim = GetComponent<Animator>();
        Ccol = GetComponent<CircleCollider2D>();
        reference = this;
        startSpeed = speed;
        Score = 1;
        Health = 3;
        StartScoreMultiplier = ScoreMultiplier;
        GAMEOVER = GameObject.Find("GameOver");
        GAMEOVER.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menu.name);
        }

        if (GAMEOVER.active == false)
        {
            // Score timer
            if (Time.timeSinceLevelLoad > nextActionTime)
            {
                nextActionTime += period;




                Score += 1 * ScoreMultiplier;

                if (Time.timeSinceLevelLoad > NextMultiPlierTime)
                {
                    NextMultiPlierTime += MultiplierPeriod;

                    ScoreMultiplier += 1;
                    //afspiller cykel lyd
                    //AudioManager.audioManager.playSound(0);
                }
            }



            //speed ramping
            speed = speed * (1 + multiplier / 100);


            //jump
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    //nothing
                }
                else if (isGrounded)
                {
                    Anim.SetInteger("state", 2);
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                    isGrounded = false;
                }
                
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W))
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

	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" && GAMEOVER.active == false)
        {
            isGrounded = true;
        }

        //Enemy Collision
        if(collision.gameObject.tag == "Obstacle")
        {
            if (GAMEOVER.active == false)
            {
                Health -= 1;
                if (Health != 0)
                {
                    AudioManager.audioManager.playSound(1);
                }

                //speed = startSpeed;
                if ((speed * 0.75F) > startSpeed)
                {
                    speed = speed * 0.75F;
                }
                ScoreMultiplier = StartScoreMultiplier;
            }


            if (Health == 0)
            {
                speed = 0;
                ScoreMultiplier = 0;
                GAMEOVER.SetActive(true);
                isGrounded = false;
                Anim.enabled = false;
                //gameOver
                AudioManager.audioManager.playSound(2);
            }
        }
    }
}
