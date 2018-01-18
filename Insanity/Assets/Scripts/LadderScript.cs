using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

public class LadderScript : MonoBehaviour {

	float minX;
	float maxX;
	float minY;
	float maxY;

	private bool _canInteract = false;
	private CharController2D _controller;
	private PlayerMovement _playerMovement;
	private Vector3 _velocity;

	public Transform initialPos;
	public Transform finalPos;
	public Transform midPoint;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		_controller = player.GetComponent<CharController2D> ();
		_playerMovement = player.GetComponent<PlayerMovement> ();

		minX = GetComponent<Collider2D> ().bounds.min.x;
		maxX = GetComponent<Collider2D> ().bounds.max.x;
		minY = GetComponent<Collider2D> ().bounds.min.y;
		maxY = GetComponent<Collider2D> ().bounds.max.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (_canInteract) {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				_controller.enabled = false;
				StartCoroutine (goUpstairs ());
				
			} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				_controller.enabled = false;
				StartCoroutine (goDownstairs ());
			} 
		}else {
			
			_controller.enabled = true;
		}

		if (player.transform.position.x >= minX && player.transform.position.x <= maxX) {
			if (player.transform.position.y >= minY && player.transform.position.y <= maxY) {
				
				_canInteract = true;

			} else {
				_canInteract = false;
			}
		} else {
			_canInteract = false;
		}



	}

	IEnumerator goUpstairs(){
		if (player.transform.position.y < midPoint.position.y) {
			player.transform.position = finalPos.transform.position;
		}
		yield return null;
	}

	IEnumerator goDownstairs(){
		if (player.transform.position.y > midPoint.position.y) {
			player.transform.position = initialPos.transform.position;
		}
		yield return null;
	}
}
