using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour {

	public GameObject exterior;
	public GameObject interior;

	bool canInteract = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canInteract) {
			if (Input.GetKeyDown (KeyCode.F)) {
				exterior.SetActive (false);
				interior.SetActive (true);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		canInteract = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		canInteract = false;
	}
}
