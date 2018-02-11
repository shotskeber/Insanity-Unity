using UnityEngine;
using Fungus;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Inventory/DialogueInfo")]
public class DialogueItem : ScriptableObject
{

    new public string name = "New Item";    // Name of the item
    [TextArea(15, 20)]
    public string infoGained = "";
    //public Sprite icon = null;              // Item icon
    //public bool showInInventory = true;

    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
       // if (GameManager.instance.isTalking)
      //  {
            Fungus.Flowchart.BroadcastFungusMessage(name);
            Debug.Log(name);
      //  }
        // Use the item
        // Something may happen
    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        DialogueInventory.instance.Remove(this);
    }

}
