using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lustre : MonoBehaviour {
    
	
	public IA_Boss_01 iaBossScript;
	public bool fireActive = false;

	public ParticleSystem fireParticles;
	private Animation lustreFall;
	// Use this for initialization
	void Start () {
		fireParticles.enableEmission = false;
		lustreFall = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LustreFall() {
		lustreFall.Play();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(fireActive) {
			if(other.CompareTag("Boss")) {
				iaBossScript.isStuned = true;
				iaBossScript.GetComponent<IA_Boss_01>().bossHealthPoints -= 1;
				Debug.Log("Boss 01 DEFEATED");
			}
		} else {
				iaBossScript.isStuned = true;
		}
	}
}
