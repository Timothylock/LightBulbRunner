using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

	public GameObject Player;
	public GameObject Path_I;
	public int sightRange;

	private Vector3 currSpawn;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnCollisionEnter (Collision other) {
		//if (other.gameObject.CompareTag("") {
			// do something
		//}
	}

	void OnCollisionExit (Collision other) {
		//if (other.gameObject.CompareTag("") {
			// do something
		//}
	}




	// How long is the path going down?
	void GenerateLength () {
		//pathLength = Random.Range (minPathLength, maxPathLength);

		currSpawn = Path_I.GetComponent<PathBlock> ().spawnPoints [0].position;

		GameObject p = Instantiate (Path_I, currSpawn, Quaternion.identity) as GameObject;

		currSpawn = p.GetComponent<PathBlock> ().spawnPoints [0].position;


	}

}
