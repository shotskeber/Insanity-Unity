using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {

    public int XP_points;
    public Text xp_text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xp_text.text = XP_points.ToString();
	}

    public void Sagesse_Patience_LVL1()
    {
        Debug.Log("Sagesse_Patience_LVL1");
    }

    public void Sagesse_Patience_LVL2()
    {
        Debug.Log("Sagesse_Patience_LVL2");
    }

    public void Sagesse_Mouvement_LVL1()
    {
        Debug.Log("Sagesse_Mouvement_LVL1");
    }

    public void Sagesse_Mouvement_LVL2()
    {
        Debug.Log("Sagesse_Mouvement_LVL2");
    }

    public void Sagesse_Dialogue_LVL1()
    {
        Debug.Log("Sagesse_Dialogue_LVL1");
    }

    public void Sagesse_Dialogue_LVL2()
    {
        Debug.Log("Sagesse_Dialogue_LVL2");
    }

    public void Folie_VisibiliteCharisme_LVL1()
    {
        Debug.Log("Folie_VisibiliteCharisme_LVL1");
    }

    public void Folie_VisibiliteCharisme_LVL2()
    {
        Debug.Log("Folie_VisibiliteCharisme_LVL2");
    }

    public void Folie_MouvementPatience_LVL1()
    {
        Debug.Log("Folie_MouvementPatience_LVL1");
    }

    public void Folie_MouvementPatience_LVL2()
    {
        Debug.Log("Folie_MouvementPatience_LVL2");
    }

    public void Folie_Dialogue_LVL1()
    {
        Debug.Log("Folie_Dialogue_LVL1");
    }

    public void Folie_Dialogue_LVL2()
    {
        Debug.Log("Folie_Dialogue_LVL2");
    }
}
