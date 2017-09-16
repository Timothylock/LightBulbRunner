﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int lives;
    public int speed;
	private int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            DropLife();
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
            //Destroy(other.gameObject);
        }
		if (other.CompareTag ("Lightbulb")) {
			other.gameObject.SetActive (false);
			score += 1;
			SetCountText ();
		}
    }

    private void DropLife()
    {
        lives--;

        if (lives == 0)
        {
            // Set gameover
        }
    }

	private void SetCountText() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
