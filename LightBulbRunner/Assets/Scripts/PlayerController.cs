using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives;
    public int speed;

	// Use this for initialization
	void Start () {
		
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
    }

    private void DropLife()
    {
        lives--;

        if (lives == 0)
        {
            // Set gameover
        }
    }
}
