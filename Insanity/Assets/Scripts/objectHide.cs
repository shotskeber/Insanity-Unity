using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

public class objectHide : MonoBehaviour {

	float minX;
	float maxX;
	float minY;
	float maxY;

	private bool _canInteract = false;
	private CharController2D _controller;
	private PlayerMovement _playerMovement;
	private Vector3 _velocity;

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
			if (Input.GetKeyDown(KeyCode.H)) {
				_controller.enabled = false;
				StartCoroutine (takeCover ());

			} else if (Input.GetKeyDown(KeyCode.H)) {
				_controller.enabled = false;
				StartCoroutine (exitCover ());
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

	IEnumerator takeCover(){
		var elapsedTime = 0f;
		Vector3 startingPos = transform.position;
		while (elapsedTime < 0.5f)
		{
			transform.position = Vector3.Lerp(startingPos, gameObject.transform.position, (elapsedTime / 0.5f));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		yield return null;
	}

	IEnumerator exitCover(){
		var elapsedTime = 0f;
		Vector3 startingPos = transform.position;
		while (elapsedTime < 0.5f)
		{
			transform.position = Vector3.Lerp(startingPos, gameObject.transform.position, (elapsedTime / 0.5f));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		yield return null;
	}
}
