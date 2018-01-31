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
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (exterior.activeSelf) {
					exterior.SetActive (false);
					interior.SetActive (true);
				} else {
					exterior.SetActive (true);
					interior.SetActive (false);
				}
			}
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


}
