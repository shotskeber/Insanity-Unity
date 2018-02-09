using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldItem : MonoBehaviour {

    private int itemHeld = 0;
    public int itemInHand
    {
        get { return itemHeld; }
        set
        {
            if (itemHeld == value)
                return;

            itemHeld = value;
            GameManager.instance.heldItem = value;
        }
    }
    // Use this for initialization
    void Start () {
		if(GameManager.instance.heldItem != itemHeld)
        {
            itemHeld = GameManager.instance.heldItem;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemInHand = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemInHand = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            itemInHand = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            itemInHand = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            itemInHand = 5;
        }

    }
}
