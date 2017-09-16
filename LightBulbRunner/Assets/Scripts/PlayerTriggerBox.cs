using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag("Path_I")) {
			//Destroy(other.gameObject);
			Vector3 newPos = new Vector3 (other.transform.position.x, other.transform.position.y, other.transform.position.z - 33);
			other.transform.position = newPos; 
		}
	}
}
