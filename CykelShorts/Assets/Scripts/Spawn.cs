using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject[] spawnies;
    public float minCooldown;
    public float maxCooldown;
    float timeStamp;
	// Use this for initialization
	void Start ()
    {
        timeStamp = Time.time + Random.Range(minCooldown, maxCooldown);
	}
	
	// Update is called once per frame
	void Update () {
        if (timeStamp <= Time.time)
        {
            Instantiate(spawnies[Random.Range(0, spawnies.Length)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            timeStamp = Time.time + Random.Range(minCooldown, maxCooldown);
        }
	}
}
