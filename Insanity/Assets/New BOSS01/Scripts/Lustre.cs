using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lustre : MonoBehaviour {

    public Transform wpUP;
    public Transform wpDOWN;

    public IA_Boss_01 iaBossScript;
	public bool fireActive = false;
    public bool lustreIsDown = false;
    public Collider2D col;
	public ParticleSystem fireParticles;
    //public Animator lustreAnimator;
	public Animation lustreFall;
    public Animation lustreUpward;
    public GameObject particlesFallingOnGround;
   //public Animation lustreAnim;

    private bool _canInteract = false;

	// Use this for initialization
	void Start () {
		fireParticles.enableEmission = false;
		lustreFall = GetComponent<Animation>();
        
	}

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localPosition == new Vector3(transform.position.x, -3.8f, transform.position.z))
        {
            particlesFallingOnGround.SetActive(true);
        }

        //-----------------
        if (_canInteract && fireActive) {
				iaBossScript.isStuned = true;
				iaBossScript.GetComponent<IA_Boss_01>().bossHealthPoints = 0;
				Debug.Log("Boss 01 DEFEATED");
		}

		if(_canInteract){
			iaBossScript.isStuned = true;
		}
		//--------------------------------------------------------
		if (fireActive)
        {
            fireParticles.enableEmission = true;
        }
        else
        {
            fireParticles.enableEmission = false;
        }
    }


    public void LustreFall() {
        //lustreAnim.Play(lustreAnim.clip.name = "lustreFalling_v2");
        lustreFall.Play();
        lustreIsDown = true;
        StartCoroutine(Wait());
    }

    public void LustreReverse()
    {
        //lustreAnim.Play(lustreAnim.clip.name = "lustreUpWard_v2");
        //lustreUpward.Play();
        this.transform.position = new Vector3(wpUP.position.x, wpUP.position.y, wpUP.position.z);
        particlesFallingOnGround.SetActive(false);
        lustreIsDown = false;
        col.enabled = true;
        //StartCoroutine(GoUp());
    }

    void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Boss")){
				_canInteract = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Boss")){
				_canInteract = false;
		}
	}

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        col.enabled = false;
        yield return null;
    }

    /*
    public IEnumerator GoDown()
    {

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(wpDOWN.transform.position.x, wpDOWN.transform.position.y, wpDOWN.transform.position.z), 1f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, -3.89f, 0f), 1f);

        yield return new WaitForSeconds(2f);

        if (this.gameObject.GetComponent<Transform>().position == new Vector3(0f, -3.89f, 0f))
        {
            lustreIsDown = true;
            //lustreFall.Play();
        }
        yield return null;
    }

    public IEnumerator GoUp()
    {

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(wpUP.transform.position.x, wpUP.transform.position.y, wpUP.transform.position.z), 1f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, -0f, 0f), 1f);

        yield return new WaitForSeconds(2f);

        if (this.gameObject.GetComponent<Transform>().position == new Vector3(0f, -0f, 0f))
        {
            lustreIsDown = false;
            //lustreFall.Play("LustreGoUp");
        }
        yield return null;
    }
     */
}
