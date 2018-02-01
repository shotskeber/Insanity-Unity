﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manivelle : MonoBehaviour {
    public Lustre lustreScript;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lustreScript.LustreReverse();
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
