using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlanksPack : MonoBehaviour {

    public GameObject playerPlank;
    public bool p1;
    public bool p2;
    public bool p3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (p1)
        {

        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            playerPlank.SetActive(true);
        }

    }
}
