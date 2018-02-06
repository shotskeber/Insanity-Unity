using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocleManivelle : MonoBehaviour {
    public Lustre lustreScript;
    public GameObject manivelle;
    public bool manivelleON = false;

    bool _canInteract = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && _canInteract)
        {
            manivelleON = true;
            manivelle.SetActive(true);
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && manivelleON == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("GO SMT");
                
                if (lustreScript.lustreIsDown) //lustre go up if lustre down;
                {
                    lustreScript.LustreReverse();
                } 
                else if (!lustreScript.lustreIsDown) //lustre go down if lustre up;
                {
                    lustreScript.LustreFall();
                }
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Manivelle")
        {
            _canInteract = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Manivelle")
        {
            _canInteract = false;
        }
    }
}
