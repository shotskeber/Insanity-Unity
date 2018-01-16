using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour {

	public GameObject exterior;
	public GameObject interior;

	float minX;
	float maxX;

	bool _canInteract = false;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		minX = GetComponent<Collider2D> ().bounds.min.x;
		maxX = GetComponent<Collider2D> ().bounds.max.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (_canInteract) {
			if (Input.GetKeyDown (KeyCode.F)) {
				if (exterior.activeSelf) {
					exterior.SetActive (false);
					interior.SetActive (true);
				} else {
					exterior.SetActive (true);
					interior.SetActive (false);
				}
			}
		}

		if (player.transform.position.x >= minX && player.transform.position.x <= maxX) {
			_canInteract = true;
		} else {
			_canInteract = false;
		}

	}

}
