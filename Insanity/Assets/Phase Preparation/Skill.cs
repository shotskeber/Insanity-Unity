using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour {

    Image image;
    public SkillManager skillManager_Script;
    public int skillCost;
    public bool unlocked = false;
    public GameObject skillOutline;
    public Text skillCost_Text;
    public GameObject[] costIcon;

    public bool _isLVL1 = false;
    public GameObject[] preSkills;

    private bool _canUnlock = true;
    private bool _verifyPreSkill = true;

	// Use this for initialization
	void Start () {
        if (!_isLVL1)
        {
            _canUnlock = false;
            _verifyPreSkill = true;
        } else
        {
            _canUnlock = true;
            _verifyPreSkill = false;
        }

        image = GetComponent<Image>();
        skillCost_Text.text = skillCost.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        if (!_isLVL1 && _verifyPreSkill)
        {
            for (int i = 0; i < preSkills.Length; i++)
            {
                if (preSkills[i].GetComponent<Skill>().unlocked == true)
                {
                    _canUnlock = true;
                    _verifyPreSkill = false;
                    break;
                }
            }
        }

        if (skillOutline.activeInHierarchy == true && Input.GetKeyUp(KeyCode.E) && _canUnlock == true) {
            unlocked = true;
        }

        if(skillManager_Script.XP_points >= skillCost)
        {
            if (unlocked && _canUnlock)
            {
                SkillUnlocked();
            }
        }
	}

    void SkillUnlocked()
    {
        skillManager_Script.XP_points -= skillCost;
        image.color = Color.green;
        _canUnlock = false;
        costIcon[0].SetActive(false);
        costIcon[1].SetActive(false);

        switch (skillEffect)
        {
            case SkillEffect.Sagesse_Patience_LVL1:
                {
                    skillManager_Script.Sagesse_Patience_LVL1();
                    break;
                }

            case SkillEffect.Sagesse_Patience_LVL2:
                {
                    skillManager_Script.Sagesse_Patience_LVL2();
                    break;
                }

            case SkillEffect.Sagesse_Mouvement_LVL1:
                {
                    skillManager_Script.Sagesse_Mouvement_LVL1();
                    break;
                }

            case SkillEffect.Sagesse_Mouvement_LVL2:
                {
                    skillManager_Script.Sagesse_Mouvement_LVL2();
                    break;
                }

            case SkillEffect.Sagesse_Dialogue_LVL1:
                {
                    skillManager_Script.Sagesse_Dialogue_LVL1();
                    break;
                }

            case SkillEffect.Sagesse_Dialogue_LVL2:
                {
                    skillManager_Script.Sagesse_Dialogue_LVL2();
                    break;
                }

            case SkillEffect.Folie_VisibiliteCharisme_LVL1:
                {
                    skillManager_Script.Folie_VisibiliteCharisme_LVL1();
                    break;
                }

            case SkillEffect.Folie_VisibiliteCharisme_LVL2:
                {
                    skillManager_Script.Folie_VisibiliteCharisme_LVL2();
                    break;
                }

            case SkillEffect.Folie_MouvementPatience_LVL1:
                {
                    skillManager_Script.Folie_MouvementPatience_LVL1();
                    break;
                }

            case SkillEffect.Folie_MouvementPatience_LVL2:
                {
                    skillManager_Script.Folie_MouvementPatience_LVL2();
                    break;
                }

            case SkillEffect.Folie_Dialogue_LVL1:
                {
                    skillManager_Script.Folie_Dialogue_LVL1();
                    break;
                }

            case SkillEffect.Folie_Dialogue_LVL2:
                {
                    skillManager_Script.Folie_Dialogue_LVL2();
                    break;
                }
        }
    }

    public SkillEffect skillEffect;
    public enum SkillEffect
    {
        Sagesse_Patience_LVL1,
        Sagesse_Patience_LVL2,
        Sagesse_Mouvement_LVL1,
        Sagesse_Mouvement_LVL2,
        Sagesse_Dialogue_LVL1,
        Sagesse_Dialogue_LVL2,
        Folie_VisibiliteCharisme_LVL1,
        Folie_VisibiliteCharisme_LVL2,
        Folie_MouvementPatience_LVL1,
        Folie_MouvementPatience_LVL2,
        Folie_Dialogue_LVL1,
        Folie_Dialogue_LVL2
    }
}
