using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class DialogueInventorySlot : MonoBehaviour
{

    public Text info;
    public Button removeButton;

    DialogueItem item;  // Current item in the slot

    // Add item to the slot
    public void AddItem(DialogueItem newItem)
    {
        item = newItem;

        info.text = item.infoGained;
        info.enabled = true;
        //removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        info.text = "";
        info.enabled = false;
        //removeButton.interactable = false;
    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {
        DialogueInventory.instance.Remove(item);
    }

    // Use the item
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}