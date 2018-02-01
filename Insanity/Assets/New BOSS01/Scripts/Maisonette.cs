using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maisonette : MonoBehaviour {

	public GameObject exterior;
	public GameObject interior;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Player"))
		exterior.SetActive(false);
		interior.SetActive(true);
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Player"))
		exterior.SetActive(true);
		interior.SetActive(false);
	}
}
