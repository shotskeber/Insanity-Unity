using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteraction : MonoBehaviour {

    public GameObject textInfo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textInfo.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textInfo.SetActive(false);
        }
    }
}
