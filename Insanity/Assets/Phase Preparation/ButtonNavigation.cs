﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNavigation : MonoBehaviour {

	public int index = 0;
	public int journauxIndex = 0;
    public int journalPagesIndex = 0;
	public GameObject[] outlines;
	public GameObject[] objects;
	public bool _canInteract;
    public AutoFlip bookFlipScript;
	//public int objs = 5;
	//public float xOffset = 1f;

	// Use this for initialization
	void Start () {
		_canInteract = true;
    }
	


	// Update is called once per frame
	void Update () {



        OnSelected();
		OnClick();

		if(objects[3].activeInHierarchy == true){
			CoupuresJournauxSelection();
		}

        if (objects[1].activeInHierarchy == true)
        {
            JournalSelection();
        }

        if (_canInteract){
			if(Input.GetKeyDown (KeyCode.RightArrow)){
				index++;
				if(index > 4){
					index = 0;
				}
			}
			if(Input.GetKeyDown (KeyCode.LeftArrow)){
				index--;
				if(index < 0){
					index = 4;
				}
			}
		} else {
			if(Input.GetKeyDown (KeyCode.Escape)){
				_canInteract = true;
				objects[0].SetActive(false);
				objects[1].SetActive(false);
				objects[2].SetActive(false);
				objects[3].SetActive(false);
				objects[4].SetActive(false);
			}
		}
	}

    void JournalSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { 
            bookFlipScript.FlipLeftPage();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bookFlipScript.FlipRightPage();
        }
    }


	void CoupuresJournauxSelection(){
        if (journauxIndex == 0)
        {
            objects[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
        }
        else if (journauxIndex == 1)
        {
            objects[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(-540f, 0f);
        }
        else if (journauxIndex == 2)
        {
            objects[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1080f, 0f);
        }
        float coupuresJPos = objects[3].GetComponent<RectTransform>().position.x;
			if(Input.GetKeyDown (KeyCode.RightArrow)){
				journauxIndex++;

                //Debug.Log("RIGHTSlide");
				//coupuresJPos =+ 540f;
				//objects[3].GetComponent<RectTransform>().position = new Vector2(objects[3].GetComponent<RectTransform>().position.x + 540f, objects[3].GetComponent<RectTransform>().position.y);
				if(journauxIndex > 2){
					journauxIndex = 0;
				}
			}
			if(Input.GetKeyDown (KeyCode.LeftArrow)){
				journauxIndex--;
				//Debug.Log("LEFTSlide");
				//coupuresJPos =- 540f;
				//objects[3].GetComponent<RectTransform>().position = new Vector2(objects[3].GetComponent<RectTransform>().position.x - 540f, objects[3].GetComponent<RectTransform>().position.y);
				if(journauxIndex < 0){
					journauxIndex = 2;
				}
			}
	}


	void OnClick(){
		if(Input.GetKeyDown (KeyCode.E)){
		_canInteract = false;
			if(index == 0) {
				objects[0].SetActive(true);
				objects[1].SetActive(false);
				objects[2].SetActive(false);
				objects[3].SetActive(false);
				objects[4].SetActive(false);
				//Debug.Log("1");
			} else if(index == 1) { // journal
				objects[0].SetActive(false);
				objects[1].SetActive(true);
				objects[2].SetActive(false);
				objects[3].SetActive(false);
				objects[4].SetActive(false);
				//Debug.Log("2");
			} else if(index == 2) {
				objects[0].SetActive(false);
				objects[1].SetActive(false);
				objects[2].SetActive(true);
				objects[3].SetActive(false);
				objects[4].SetActive(false);
				//Debug.Log("3");
			} else if(index == 3) { // coupures de journaux
				objects[0].SetActive(false);
				objects[1].SetActive(false);
				objects[2].SetActive(false);
				objects[3].SetActive(true);
				objects[4].SetActive(false);
				//Debug.Log("4");
			} else if(index == 4) {
				objects[0].SetActive(false);
				objects[1].SetActive(false);
				objects[2].SetActive(false);
				objects[3].SetActive(false);
				objects[4].SetActive(true);
				//Debug.Log("5");
			}
		}
	}

	void OnSelected() {
			if(index == 0) {
			outlines[0].SetActive(true);
			outlines[1].SetActive(false);
			outlines[2].SetActive(false);
			outlines[3].SetActive(false);
			outlines[4].SetActive(false);
		} else if(index == 1) { // journal
			outlines[0].SetActive(false);
			outlines[1].SetActive(true);
			outlines[2].SetActive(false);
			outlines[3].SetActive(false);
			outlines[4].SetActive(false);
		} else if(index == 2) {
			outlines[0].SetActive(false);
			outlines[1].SetActive(false);
			outlines[2].SetActive(true);
			outlines[3].SetActive(false);
			outlines[4].SetActive(false);
		} else if(index == 3) { // coupures de journaux
			outlines[0].SetActive(false);
			outlines[1].SetActive(false);
			outlines[2].SetActive(false);
			outlines[3].SetActive(true);
			outlines[4].SetActive(false);
		} else if(index == 4) {
			outlines[0].SetActive(false);
			outlines[1].SetActive(false);
			outlines[2].SetActive(false);
			outlines[3].SetActive(false);
			outlines[4].SetActive(true);
			}
		}
	}
