using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PnjTrigger : MonoBehaviour
{

    public string DialogueToSay = "";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
