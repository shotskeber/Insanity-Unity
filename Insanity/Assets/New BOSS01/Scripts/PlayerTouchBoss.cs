using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health_Boss01>().playerHealth = 0;
        }
    }
}
