using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public Item item;   // Item to put in the inventory if picked up

    bool _canInteract = false;

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
        }
    }
    // Pick up the item
	void PickUp()
    {
        Inventory.instance.Add(item);   // Add to inventory

        Destroy(gameObject);    // Destroy item from scene
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