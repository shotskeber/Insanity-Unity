using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorche : MonoBehaviour
{
    public IA_Boss_01 iaBossScript;
    public bool fireActive = false;
    public Lustre lustreSCript;
    public SpriteRenderer playerTorche_spr;
    public Sprite torcheAlume;
    public Sprite torcheEtteinte;
    private ParticleSystem fireParticles;

    // Use this for initialization
    void Start()
    {
        fireParticles = this.gameObject.GetComponent<ParticleSystem>();
        fireParticles.enableEmission = false;

    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sortingLayerName == "Platforms")
        {
            fireParticles.enableEmission = false;
            fireActive = false;
            playerTorche_spr.sprite = torcheEtteinte;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (fireActive)
        {
            /*
            if (other.CompareTag("Boss") && iaBossScript.isStuned)
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
            */
        }
        else {
            if (other.gameObject.name == "WallTorche") {
                fireParticles.enableEmission = true;
                fireActive = true;
                playerTorche_spr.sprite = torcheAlume;
            }

        }


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (fireActive)
        {
            if (other.gameObject.name == "MeuleFoin" && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(other.GetComponent<MeuleFoinsInflamable>().BurningMeule());
            }

            if (other.gameObject.name == "LitLustre" && Input.GetKeyDown(KeyCode.E))
            {
                lustreSCript.fireActive = true;
            }
        }
    }
}
