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
	private Animation lustreFall;
	// Use this for initialization
	void Start () {
		fireParticles.enableEmission = false;
		lustreFall = GetComponent<Animation>();

	}

    // Update is called once per frame
    void Update()
    {
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
        lustreFall.Play();
        lustreIsDown = true;
        StartCoroutine(Wait());
    }

    public void LustreReverse()
    {
        this.transform.position = new Vector3(wpUP.position.x, wpUP.position.y, wpUP.position.z);
        lustreIsDown = false;
        col.enabled = true;
        //StartCoroutine(GoUp());
    }

    void OnTriggerEnter2D(Collider2D other){

        if (fireActive) {
			if(other.CompareTag("Boss")) {
				iaBossScript.isStuned = true;
				iaBossScript.GetComponent<IA_Boss_01>().bossHealthPoints = 0;
				Debug.Log("Boss 01 DEFEATED");
			}
		} else {
            if (other.CompareTag("Boss"))
            {
                iaBossScript.isStuned = true;
            }
        }
	}

    public IEnumerator GoDown()
    {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(wpDOWN.transform.position.x,
                                 wpDOWN.transform.position.y, wpDOWN.transform.position.z), 1f);


        yield return new WaitForSeconds(2f);

        if (this.gameObject.GetComponent<Transform>().position == wpDOWN.transform.position)
        {
            lustreIsDown = true;
            //lustreFall.Play();
        }
        yield return null;
    }

    public IEnumerator GoUp()
    {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(wpUP.transform.position.x,
                                 wpUP.transform.position.y, wpUP.transform.position.z), 1f);

            yield return new WaitForSeconds(2f);

        if (this.gameObject.GetComponent<Transform>().position == wpUP.transform.position)
        {
            lustreIsDown = false;
            //lustreFall.Play("LustreGoUp");
        }
        yield return null;
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        col.enabled = false;
        yield return null;
    }
}
