using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueInventory : MonoBehaviour {
    #region Singleton

    public static DialogueInventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //public int space = 20;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<DialogueItem> info = new List<DialogueItem>();

    // Add a new item if enough room
    public void Add(DialogueItem item)
    {
            if (info.Contains(item))
            {
                return;
            }

            info.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
    }

    // Remove an item
	public void Remove(DialogueItem item)
    {
        info.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}


