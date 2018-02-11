using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeuleFoinsInflamable : MonoBehaviour {

    public bool isBurning = false;
    public IA_Boss_01 iaBossScript;
    public int bossDammagesTakken;
    public GameObject fireFx;
    //private ParticleSystem fireParticles;


    // Use this for initialization
    void Start () {
        //fireParticles = this.gameObject.GetComponent<ParticleSystem>();
        //fireParticles.enableEmission = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (isBurning)
        {
            
            if (other.CompareTag("Boss") && iaBossScript.isStuned)
            {
                iaBossScript.GetComponent<IA_Boss_01>().bossHealthPoints = bossDammagesTakken;
                Debug.Log("BOSS TAKE DAMAGE");
                //fireParticles.enableEmission = false;
                //fireFx.SetActive(false);
            }
        }
    }

    public IEnumerator BurningMeule()
    {
        //fireParticles.enableEmission = true;
        fireFx.SetActive(true);
        isBurning = true;
        yield return new WaitForSeconds(10f);
        //fireParticles.enableEmission = false;
        fireFx.SetActive(false);
        isBurning = false;
        yield return null;
    }
}
