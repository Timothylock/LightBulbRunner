using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Prop {
	public GameObject prefab;
}

[System.Serializable]
public struct GridCell {
	public GameObject instantiatedProp;
}

public class PathBlock : MonoBehaviour {
	public Transform[] spawnPoints;
	public Transform props;

	public Prop obstacle2x1;
	public Prop obstacle1x1;
	public Prop pickup1x1;

	public float prob2x1;
	public float probPickup;

	private GameObject[,] grid = new GameObject[3, 3];

	// Use this for initialization
	void Start () {
		GenerateProps();
	}

	void GenerateProps() {
		bool gen2x1 = Random.value < prob2x1;
		if (gen2x1) {
			PlaceObstacle2x1();
		} else {
			PlaceObstacle1x2();
		}
		PlaceObstacles1x1();
		PlacePickups();
	}

	void PlaceObstacle2x1() {
		bool left = Random.value < 0.5;
		Vector3 localSpawnPoint = new Vector3(left ? -0.5f : 0.5f, 0f, 0f);

		GameObject prop = Instantiate(obstacle2x1.prefab, props);
		prop.transform.localPosition = localSpawnPoint;

		grid[1, 1] = prop;
		grid[left ? 0 : 2, 1] = prop;
	}

	void PlaceObstacle1x2() {
		
		int pos = Mathf.FloorToInt(Random.value / 0.26f);
		GameObject prop = Instantiate(obstacle2x1.prefab, props);
		prop.transform.localRotation = Quaternion.Euler(0, 90, 0);
		/*
			23
			01
		*/
		switch(pos){
		case 0:
			grid[0, 0] = prop;
			grid[0, 1] = prop;
			prop.transform.localPosition = new Vector3(-1, 0, -1);
			break;
		case 1:
			grid[2, 0] = prop;
			grid[2, 1] = prop;
			prop.transform.localPosition = new Vector3(1, 0, -1);
			break;
		case 2:
			grid[0, 1] = prop;
			grid[0, 2] = prop;
			prop.transform.localPosition = new Vector3(-1, 0, 1);
			break;
		case 3:
			grid[2, 1] = prop;
			grid[2, 2] = prop;
			prop.transform.localPosition = new Vector3(1, 0, 1);
			break;
		}
	}

	void PlaceObstacles1x1() {
		// only on corners
		foreach (int x in new[] {-1, 1}) {
			if (grid[x+1, 1] != null) {
				// decide whether to generate
				if (Random.value < 0.3) {
					bool isTop = Random.value < 0.5;
					if (grid[x + 1, isTop ? 2 : 0] != null)
						continue;
					Vector3 localSpawnPoint = new Vector3(x, 0, isTop ? 1: -1);
					GameObject prop = Instantiate(obstacle1x1.prefab, props);
					prop.transform.localPosition = localSpawnPoint;

					grid[x + 1, isTop ? 2 : 0] = prop;
				}
			}
		}
	}

	void PlacePickups() {
		for (int x = -1; x < 1; x++) {
			for (int y = -1; y < 1; y++) {
				if (grid[x + 1, y + 1] == null && Random.value < probPickup) {
					GameObject prop = Instantiate(pickup1x1.prefab, props);
					prop.transform.localPosition = new Vector3(x, 0, y);

					grid[x + 1, y + 1] = prop;
				}
			}
		}
	}

	[ContextMenu ("Shuffle")]
	public void ShuffleProps() {
		for (int x = -1; x < 1; x++) {
			for (int y = -1; y < 1; y++) {
				grid[x + 1, y + 1] = null;
			}
		}
		foreach (Transform child in props) {
			Destroy(child.gameObject);
		}
		GenerateProps();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
