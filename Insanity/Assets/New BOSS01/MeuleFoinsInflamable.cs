using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeuleFoinsInflamable : MonoBehaviour {

    public bool isBurning = false;
    public IA_Boss_01 iaBossScript;

    private ParticleSystem fireParticles;


    // Use this for initialization
    void Start () {
        fireParticles = this.gameObject.GetComponent<ParticleSystem>();
        fireParticles.enableEmission = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isBurning)
        {
            if (other.CompareTag("Boss"))
            {
                iaBossScript.GetComponent<IA_Boss_01>().bossHealthPoints -= 1;
                fireParticles.enableEmission = false;
            }
        }
    }

    public IEnumerator BurningMeule()
    {
        fireParticles.enableEmission = true;
        isBurning = true;
        yield return new WaitForSeconds(5f);
        fireParticles.enableEmission = false;
        isBurning = false;
        yield return null;
    }
}
