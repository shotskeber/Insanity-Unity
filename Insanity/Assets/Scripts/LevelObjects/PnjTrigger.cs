using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PnjTrigger : MonoBehaviour
{

    public string DialogueToSay = "";
    private Collider2D player;
    private Collider2D[] self;
    private Collider2D selfCollider;
   

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        self = GetComponents<Collider2D>();

        foreach (Collider2D c in self)
        {
            if (!c.isTrigger)
            {
                selfCollider = c;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Player")
        {
            selfCollider.enabled = true;
        }
        else
        {
            selfCollider.enabled = false;
           // Physics2D.IgnoreCollision(player, selfCollider, false);
        }
        }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Player")
            {
                Fungus.Flowchart.BroadcastFungusMessage(DialogueToSay);

            }
        }

    }
}
