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

	public Transform teleportPos;
	public Transform finalPos;

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
			if (Input.GetKey(KeyCode.UpArrow)) {
				if (player.transform.position.y < teleportPos.position.y) {
					_playerMovement.gravity = 0;
					_velocity.y = 5f;
					_velocity = new Vector3 (0f, _velocity.y, 0f);
					_controller.move (_velocity * Time.deltaTime);
					_velocity = _controller.velocity;
					StartCoroutine (goUpstairs ());
				}
				
			} else if (Input.GetKey(KeyCode.DownArrow)) {
				_playerMovement.gravity = 0;
				_velocity.y = -5f;
				_velocity = new Vector3 (0f, _velocity.y, 0f);
				_controller.move( _velocity * Time.deltaTime );
				_velocity = _controller.velocity;
			} 
		}else {
			
			_velocity.y = 0f;
		}

		if (player.transform.position.x >= minX && player.transform.position.x <= maxX) {
			if (player.transform.position.y >= minY && player.transform.position.y <= maxY) {
				
				_playerMovement.gravity = 0;
				_canInteract = true;

			} else {
				_canInteract = false;
				_playerMovement.gravity = -20f;
			}
		} else {
			player.transform.localScale = new Vector3 (2.4f, 2.4f, 2.4f);
			_canInteract = false;
			_playerMovement.gravity = -20f;
		}



	}

	IEnumerator goUpstairs(){
		while (player.transform.position.y < teleportPos.position.y) {	
			var distance = (Mathf.Clamp(Mathf.Abs(player.transform.position.y - teleportPos.position.y), 0.0f, 1f));
			var value = 0.8f + distance;
			player.transform.localScale = new Vector3 (value, value, value);
			yield return null;
		}
		player.transform.position = finalPos.position;
		yield return null;
	}

	IEnumerator goDownstairs(){
		yield return null;
	}
}
