using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

public class LadderScript : MonoBehaviour {

	float minX;
	float maxX;
	float minY;
	float maxY;

	public bool _canInteract = false;
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
				if (_controller.enabled) {
					_controller.enabled = false;
					StartCoroutine (useStairs ());
				}
			}
		}else {
			
			_controller.enabled = true;
		}



	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_canInteract = true;
		}

	}
	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag("Player"))
		{
			_canInteract = false;
		}
	}

	IEnumerator useStairs(){
		if (player.transform.position.y < midPoint.position.y) {
			player.transform.position = finalPos.transform.position;
		} else {
			player.transform.position = initialPos.transform.position;
		}
		yield return null;
	}
}
