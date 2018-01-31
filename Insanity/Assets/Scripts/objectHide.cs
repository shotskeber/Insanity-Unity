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

	private bool isHidden = false;

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

		if (isHidden) {
			player.transform.position = new Vector3 (Mathf.Clamp(player.transform.position.x, minX, maxX), player.transform.position.y, 0f);
		}

		if (_canInteract) {
			if (Input.GetKeyDown(KeyCode.H) && !isHidden) {
				_controller.enabled = false;
				StartCoroutine (takeCover ());
				isHidden = true;
			} else if(Input.GetKeyDown(KeyCode.H) && isHidden) {
				_controller.enabled = false;
				StartCoroutine (exitCover ());
				isHidden = false;
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


	IEnumerator takeCover(){
		player.GetComponent<Renderer> ().sortingLayerName = "Platforms";
		yield return null;
	}

	IEnumerator exitCover(){
		player.GetComponent<Renderer> ().sortingLayerName = "Player";
		yield return null;
	}
}
