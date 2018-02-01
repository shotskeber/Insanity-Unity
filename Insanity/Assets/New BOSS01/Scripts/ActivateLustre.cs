using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLustre : MonoBehaviour {

	public Lustre lustreScript;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Player")) {
			if(Input.GetKeyDown(KeyCode.E)) {
				lustreScript.LustreFall();
				this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
}
