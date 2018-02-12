using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour {
	
	public int mainTreeIndex = 0;
	public int sagesseIndex = 0;
	public int skillIndex = 0;
	public int treeIndex = 0;

	public GameObject[] branchOutlines;
	public GameObject[] treeBranch;
	public GameObject[] outline_skill;

	public bool sagesse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	ActivateOutlines();

	if(Input.GetKeyDown(KeyCode.Escape)){
		mainTreeIndex = 0;
		sagesseIndex = 0;
		skillIndex = 0;
	}
		//OnSelected();
		//OnClicked();
		SkillTreeSelected();
		SelectionTreeBranch();

		if(sagesseIndex == 0) {
			outline_skill[0].SetActive(true);
			outline_skill[1].SetActive(false);
			/*
			outline_skill[2].SetActive(false);
			outline_skill[3].SetActive(false);
			outline_skill[4].SetActive(false);
			outline_skill[5].SetActive(false);
			*/
		} if (sagesseIndex == 1){
			outline_skill[0].SetActive(false);
			outline_skill[1].SetActive(true);
			/*
			outline_skill[2].SetActive(false);
			outline_skill[3].SetActive(false);
			outline_skill[4].SetActive(false);
			outline_skill[5].SetActive(false);
			*/
		}

		/*
		if(treeBranch[0].activeInHierarchy == true){
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				sagesseIndex++;
				if(sagesseIndex > 1){
					sagesseIndex = 0;
				}
			}
			
			
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				sagesseIndex--;
				if(sagesseIndex < 0){
					sagesseIndex = 1;
				}
			}

			if(sagesseIndex == 0){
				if(Input.GetKeyDown(KeyCode.LeftArrow)){
					treeBranch[0].SetActive(false);
				}
			}

			
		}
		*/
	}
	/*
	void OnSelected(){
		if(treeIndex == 0){
			sagesse = true;
			branchOutlines[0].SetActive(true);
			branchOutlines[1].SetActive(false);
			//
			treeBranch[0].SetActive(true);
			treeBranch[1].SetActive(false);
		} else if (treeIndex == 1){
			sagesse = false;
			branchOutlines[0].SetActive(false);
			branchOutlines[1].SetActive(true);
			//
			treeBranch[0].SetActive(false);
			treeBranch[1].SetActive(true);
		}
	}
	*/
	/*
	void OnClicked(){
		if(mainTreeIndex == 0){
			if(Input.GetKeyDown(KeyCode.E)){
				treeBranch[0].SetActive(true);
				treeBranch[1].SetActive(false);
			}
		} else if (mainTreeIndex == 1){
			if(Input.GetKeyDown(KeyCode.E)){
				treeBranch[0].SetActive(false);
				treeBranch[1].SetActive(true);
			}
		}
	}
	*/

	void ActivateOutlines(){
		if(treeIndex == 1){
			outline_skill[0].SetActive(true);
			outline_skill[1].SetActive(false);
			outline_skill[2].SetActive(false);
			outline_skill[3].SetActive(false);
			outline_skill[4].SetActive(false);
			outline_skill[5].SetActive(false);
		} else if(treeIndex == 2){
			outline_skill[0].SetActive(false);
			outline_skill[1].SetActive(true);
			outline_skill[2].SetActive(false);
			outline_skill[3].SetActive(false);
			outline_skill[4].SetActive(false);
			outline_skill[5].SetActive(false);
		} else if(treeIndex == 3){
			outline_skill[0].SetActive(false);
			outline_skill[1].SetActive(false);
			outline_skill[2].SetActive(true);
			outline_skill[3].SetActive(false);
			outline_skill[4].SetActive(false);
			outline_skill[5].SetActive(false);
		} else if(treeIndex == 4){
			outline_skill[0].SetActive(false);
			outline_skill[1].SetActive(false);
			outline_skill[2].SetActive(false);
			outline_skill[3].SetActive(true);
			outline_skill[4].SetActive(false);
			outline_skill[5].SetActive(false);
		} else if(treeIndex == 5){
			outline_skill[0].SetActive(false);
			outline_skill[1].SetActive(false);
			outline_skill[2].SetActive(false);
			outline_skill[3].SetActive(false);
			outline_skill[4].SetActive(true);
			outline_skill[5].SetActive(false);
		} else if(treeIndex == 6){
			outline_skill[0].SetActive(false);
			outline_skill[1].SetActive(false);
			outline_skill[2].SetActive(false);
			outline_skill[3].SetActive(false);
			outline_skill[4].SetActive(false);
			outline_skill[5].SetActive(true);
		}
	}

	void SelectionTreeBranch(){
		if(treeIndex == 0){
			sagesse = true;
			branchOutlines[0].SetActive(true);
			branchOutlines[1].SetActive(false);
			//
			treeBranch[0].SetActive(true);
			treeBranch[1].SetActive(false);

			if(Input.GetKeyDown(KeyCode.DownArrow)){
				treeIndex = 10;
			}
		}

		if(sagesse){
			if(treeIndex == 0 ){
				if (Input.GetKeyDown(KeyCode.RightArrow)){
				treeIndex = 1;
			}
		}

			if(treeIndex == 1){
				if (Input.GetKeyDown(KeyCode.RightArrow)){
				treeIndex = 2;
			}
				if (Input.GetKeyDown(KeyCode.LeftArrow)){
				treeIndex = 0;
			}
		}

			if(treeIndex == 2){
				if (Input.GetKeyDown(KeyCode.LeftArrow)){
				treeIndex = 1;
			}
		}
	}




		if(treeIndex == 10){
			sagesse = false;
			branchOutlines[0].SetActive(false);
			branchOutlines[1].SetActive(true);
			//
			treeBranch[0].SetActive(false);
			treeBranch[1].SetActive(true);

			if(Input.GetKeyDown(KeyCode.UpArrow)){
				treeIndex = 0;
			}
		}
	}

	void Arrows(){
		if(Input.GetKeyDown(KeyCode.DownArrow)){
		
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)){
		
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
		
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
		
		}
	}

	void SkillTreeSelected(){
		if(Input.GetKeyDown (KeyCode.DownArrow)){
			mainTreeIndex --;
			if(mainTreeIndex < 0){
				mainTreeIndex = 1;
			}
		}

		if(Input.GetKeyDown (KeyCode.UpArrow)){
			mainTreeIndex ++;
			if(mainTreeIndex > 1){
				mainTreeIndex = 0;
			}
		}
	}
}
