using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PNJ : MonoBehaviour {

	public string DialogueToSay = "startStory";

	float maxX;
	float maxY;
	float minX;
	float minY;

	public bool _canInteract;

	GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (_canInteract) {
			if (Input.GetKeyDown (KeyCode.E)) {
				Fungus.Flowchart.BroadcastFungusMessage (DialogueToSay);
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
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _canInteract = false;
        }
    }
}
