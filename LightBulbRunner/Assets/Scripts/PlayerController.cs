using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float leftRightSpeed;
	public float jumpHeight;
	public int lives;
	public int speed;
	public Text scoreText;

	private Rigidbody rb;
	private float startingHeight;
	private bool isGrounded; 
	private int score;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		startingHeight = rb.position.y;
		//rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
		//rb.AddForce(0, 0, -speed, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {
		// Player Movement
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);

		if (Input.GetKey("a"))
			rb.AddForce(leftRightSpeed, 0, 0, ForceMode.Impulse);

		if (Input.GetKey("d"))
			rb.AddForce(-leftRightSpeed, 0, 0, ForceMode.Impulse);

		if (Input.GetKey ("w") && isGrounded) {
			isGrounded = false;
			rb.velocity += jumpHeight * Vector3.up;
		}

		if (Input.GetKeyDown ("s")) {
			transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
		}

		if (Input.GetKeyUp ("s")) {
			transform.rotation = Quaternion.AngleAxis(0, Vector3.right);
		}

		if (rb.position.y < startingHeight + 1) {
			isGrounded = true;
		}
	}

	private void OnTriggerEnter(Collider other) {
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


	private void DropLife() {
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
