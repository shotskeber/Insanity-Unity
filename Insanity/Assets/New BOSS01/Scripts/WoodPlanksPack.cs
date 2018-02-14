using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlanksPack : MonoBehaviour {

    public GameObject playerPlank;

	public Item item;   // Item to put in the inventory if picked up

	bool _canInteract = false;

    public bool p1;
    public bool p2;
    public bool p3;

    /*void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            playerPlank.SetActive(true);
        }

    }*/



	GameObject player;

	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && _canInteract)
		{
			PickUp();
			//playerPlank.SetActive(true);
		}

		if (p1)
		{

		}
	}
	// Pick up the item
	void PickUp()
	{
		Debug.Log("Picking up " + item.name);
		Inventory.instance.Add(item);   // Add to inventory

		//Destroy(gameObject);    // Destroy item from scene
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
