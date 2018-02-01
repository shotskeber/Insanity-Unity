using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWoodPlank : MonoBehaviour {

	private Animation woodHit;
	private BoxCollider2D woodPlankCollider;

	// Use this for initialization
	void Awake () {
		woodHit = GetComponent<Animation>();
		woodPlankCollider = GetComponent<BoxCollider2D>();
		woodPlankCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)) {
			StartCoroutine(WoodHit());
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Boss")) {
			other.gameObject.GetComponent<IA_Boss_01>().isStuned = true;
            this.gameObject.SetActive(false);
		}
	}

	IEnumerator WoodHit() {
	woodHit.Play();
	woodPlankCollider.enabled = true;
	yield return new WaitForSeconds(0.1f);
	woodPlankCollider.enabled = false;

	yield return null;
	}
}
