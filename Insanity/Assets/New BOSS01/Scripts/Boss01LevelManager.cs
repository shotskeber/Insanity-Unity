using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01LevelManager : MonoBehaviour {


	public GameObject phase01_RightBlocker;
	public GameObject phase02_RightBlocker;
    public IA_Boss_01 iaBoss01_script;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(iaBoss01_script.phase_2){
		phase01_RightBlocker.SetActive(false);
		}

		if(iaBoss01_script.phase_3){
		phase02_RightBlocker.SetActive(false);
		}
	}
}
