using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

	bool _canInteract = false;
    public int scenenumber = 0;
	public bool isTrigger;



	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		
		if (_canInteract) {
			if (Input.GetKeyDown (KeyCode.UpArrow) || isTrigger) {
				AutoFade.LoadLevel (scenenumber, 0.5f, 0.5f, Color.black);
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
