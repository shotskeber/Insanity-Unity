using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PNJ : MonoBehaviour {

	public string DialogueToSay = "startStory";

	float maxX;
	float maxY;
	float minX;
	float minY;

	public bool _canInteract;

	GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		minX = transform.GetComponent<Collider2D> ().bounds.min.x;
		maxX = transform.GetComponent<Collider2D> ().bounds.max.x;
		minY = transform.GetComponent<Collider2D> ().bounds.min.y;
		maxY = transform.GetComponent<Collider2D> ().bounds.max.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (_canInteract) {
			if (Input.GetKeyDown (KeyCode.F)) {
				Fungus.Flowchart.BroadcastFungusMessage (DialogueToSay);
			}
		}


		if (player.transform.position.x >= minX && player.transform.position.x <= maxX) {
			if (player.transform.position.y >= minY && player.transform.position.y <= maxY) {
				_canInteract = true;
			}else{
				_canInteract = false;
			}
		} else {
			_canInteract = false;
		}

	}
}
