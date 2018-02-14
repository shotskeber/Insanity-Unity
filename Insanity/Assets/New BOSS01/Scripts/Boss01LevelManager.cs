using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01LevelManager : MonoBehaviour {


    public GameObject phase1_Content;
	public GameObject phase2_Content;
    public GameObject phase3_Content;

	public GameObject torch;
	public GameObject woodplank;

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

		if (((GameManager.instance.heldItem - 1) < Inventory.instance.items.Count) && GameManager.instance.heldItem != 0) {

			if (Inventory.instance.items [GameManager.instance.heldItem - 1].name == "Wood Plank") {
				woodplank.SetActive (true);
			} else {
				woodplank.SetActive (false);
			}
			if (Inventory.instance.items [GameManager.instance.heldItem - 1].name == "Torche") {
				torch.SetActive (true);
			} else {
				torch.SetActive (false);
			}
		} else {
			//torch.SetActive (false);
			//woodplank.SetActive (false);
		}

	}
}
