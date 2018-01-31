using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorche : MonoBehaviour
{
    public IA_Boss_01 iaBossScript;
    public bool fireActive = false;

    private ParticleSystem fireParticles;

    // Use this for initialization
    void Start()
    {
        fireParticles = this.gameObject.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (fireActive)
        {
            if (other.CompareTag("Boss"))
            {
                iaBossScript.GetComponent<IA_Boss_01>().bossHealthPoints -= 1;
                fireParticles.enableEmission = false;
                //fire.SetActive(false);
                fireActive = false;
            }
            if (other.gameObject.name == "MeuleFoin")
            {
                StartCoroutine(other.GetComponent<MeuleFoinsInflamable>().BurningMeule());
            }
        } else {
            if (other.gameObject.name == "WallTorche") {
                fireParticles.enableEmission = true;
                fireActive = true;

            }
             
        }
    }
}
