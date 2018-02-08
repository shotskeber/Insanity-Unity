using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01LevelManager : MonoBehaviour {


    public GameObject phase1_Content;
	public GameObject phase2_Content;
    public GameObject phase3_Content;

    public IA_Boss_01 iaBoss01_script;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(iaBoss01_script.phase_2){
            phase1_Content.SetActive(false);
            phase2_Content.SetActive(true);
        }

		if(iaBoss01_script.phase_3){
            phase2_Content.SetActive(false);
            phase3_Content.SetActive(true);
        }
	}
}
