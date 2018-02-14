using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

	bool _canInteract = false;
    public int scenenumber = 0;
	public bool isTrigger;
	public enum levelSide{
		Right,
		Middle,
		Left,
		}
	public levelSide positionInLevel;
	public bool isBossEntry = false;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {

		if (_canInteract) {
			if (Input.GetKeyDown (KeyCode.UpArrow) || isTrigger) {
				if (positionInLevel == levelSide.Right) {
					GameManager.instance.spawnSide = 1;
				}else if (positionInLevel == levelSide.Left) {
					GameManager.instance.spawnSide = 3;
				}else if (positionInLevel == levelSide.Middle) {
					GameManager.instance.spawnSide = 2;
				}
				AutoFade.LoadLevel (scenenumber, 0.5f, 0.5f, Color.black);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (!isBossEntry) {
			if (collision.CompareTag ("Player")) {
				_canInteract = true;
			}
		} else if (!GameManager.instance.isDayGM) {
			if (collision.CompareTag ("Player")) {
				_canInteract = true;
			}
		}

	}
	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag("Player"))
		{
			_canInteract = false;
		}
	}
}
