using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLustre : MonoBehaviour {

	public Lustre lustreScript;
    public Animation hacheAnim;
    public GameObject lustreCorde;
    public GameObject lineRCorde;
    public GameObject manivelleSocle;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Player")) {
			if(Input.GetKeyDown(KeyCode.E)) {
				
                hacheAnim.Play();
                lustreCorde.SetActive(false);
                lineRCorde.SetActive(false);
                manivelleSocle.SetActive(false);
                StartCoroutine(Wait());
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        lustreScript.LustreFall();
        yield return null;
    }
}
