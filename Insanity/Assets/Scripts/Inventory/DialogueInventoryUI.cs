﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

/* This object manages the inventory UI. */

public class DialogueInventoryUI : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public Transform itemsParent;   // The parent object of all the items
    public Button firstSelection;

    DialogueInventory inventory;    // Our current inventory

    void Start()
    {
        inventory = DialogueInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
		StartCoroutine (lateStart ());
    }

    // Check to see if we should open/close the inventory
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.B))
        {
            firstSelection.Select();
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateUI();
        }
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    public void UpdateUI()
    {
        DialogueInventorySlot[] slots = GetComponentsInChildren<DialogueInventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.info.Count)
            {
                slots[i].AddItem(inventory.info[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

	IEnumerator lateStart(){
		yield return 0;
		inventoryUI.SetActive(!inventoryUI.activeSelf);
		UpdateUI();
		GameObject.FindGameObjectWithTag ("infoPop").transform.position += new Vector3 (0f, -100f, 0f);
	}

}