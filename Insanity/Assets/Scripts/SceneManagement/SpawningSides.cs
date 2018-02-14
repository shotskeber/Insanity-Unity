using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSides : MonoBehaviour {

	public Transform leftPos;
	public Transform midPos;
	public Transform rightPos;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		if (GameManager.instance.spawnSide == 1) {
			player.transform.position = leftPos.position;
		} else if (GameManager.instance.spawnSide == 2) {
			player.transform.position = midPos.position;
		} else if (GameManager.instance.spawnSide == 3) {
			player.transform.position = rightPos.position;
		} else {
			player.transform.position = midPos.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
