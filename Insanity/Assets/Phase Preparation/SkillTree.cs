using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour {

    public int skillIndex = 0;

    public GameObject[] outline_skill;

    public GameObject sagesseBranch;
    public GameObject sagesseOutline;

    public GameObject folieBranch;
    public GameObject folieOutline;

    public Text skillTitle;
    public Text skillDescription;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SkillSelection();
        ActivateOutlines();
        SkillDescription();
    }

    void SkillSelection()
    {
        // Sagesse -------------------------------------------------------
        if (skillIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                skillIndex = 10;
            }
        }

        if(sagesseBranch.activeInHierarchy == true)
        {
            //------------------------------------------------------------
            if (skillIndex == 0 || skillIndex == 1 || skillIndex == 2)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    skillIndex++;
                    if (skillIndex > 2)
                    {
                        skillIndex = 0;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    skillIndex--;
                    if (skillIndex < 0)
                    {
                        skillIndex = 2;
                    }
                }
            }

            if (skillIndex == 1)
            {
                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    skillIndex = 3;
                }
            }

            //------------------------------------------------------------
            if(skillIndex == 3 || skillIndex == 4)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    skillIndex++;
                    if (skillIndex > 4)
                    {
                        skillIndex = 3;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    skillIndex--;
                    if (skillIndex < 3)
                    {
                        skillIndex = 4;
                    }
                }
            }

            if (skillIndex == 3)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    skillIndex = 5;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    skillIndex = 1;
                }
            }

            //------------------------------------------------------------
            if (skillIndex == 5 || skillIndex == 6)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    skillIndex++;
                    if (skillIndex > 6)
                    {
                        skillIndex = 5;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    skillIndex--;
                    if (skillIndex < 5)
                    {
                        skillIndex = 6;
                    }
                }
            }

            if (skillIndex == 5)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    skillIndex = 3;
                }
            }

        }

        // Folie -------------------------------------------------------
        if(skillIndex == 10)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                skillIndex = 0;
            }
        }

        if (folieBranch.activeInHierarchy == true)
        {
            //------------------------------------------------------------
            if (skillIndex == 10 || skillIndex == 11 || skillIndex == 12)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    skillIndex++;
                    if (skillIndex > 12)
                    {
                        skillIndex = 10;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    skillIndex--;
                    if (skillIndex < 10)
                    {
                        skillIndex = 12;
                    }
                }
            }

            if (skillIndex == 11)
            {
                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    skillIndex = 13;
                }
            }

            //------------------------------------------------------------
            if (skillIndex == 13 || skillIndex == 14)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    skillIndex++;
                    if (skillIndex > 14)
                    {
                        skillIndex = 13;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    skillIndex--;
                    if (skillIndex < 13)
                    {
                        skillIndex = 14;
                    }
                }
            }

            if (skillIndex == 13)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    skillIndex = 15;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    skillIndex = 11;
                }
            }

            //------------------------------------------------------------
            if (skillIndex == 15 || skillIndex == 16)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    skillIndex++;
                    if (skillIndex > 16)
                    {
                        skillIndex = 15;
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    skillIndex--;
                    if (skillIndex < 15)
                    {
                        skillIndex = 16;
                    }
                }
            }

            if (skillIndex == 15)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    skillIndex = 13;
                }
            }

        }
    }

    void SkillDescription()
    {
        if (skillIndex == 0)
        {
            skillTitle.text = "Sagesse";
            skillDescription.text = "C'est la branche de la sagesse.";
        }
        else if (skillIndex == 1)
        {
            skillTitle.text = "SP_LVL1";
            skillDescription.text = "Vous êtes moins aggréssif lorsque vous discutez.";
        }
        else if (skillIndex == 2)
        {
            skillTitle.text = "SP_LVL2";
            skillDescription.text = "Vous êtes encore moins aggréssif lorsque vous discutez.";
        }
        else if (skillIndex == 3)
        {
            skillTitle.text = "SC_LVL1";
            skillDescription.text = "Vous inspirez la sympathie envers les habitants.";
        }
        else if (skillIndex == 4)
        {
            skillTitle.text = "SC_LVL2";
            skillDescription.text = "Vous inspirez encore plus la sympathie envers les habitants.";
        }
        else if (skillIndex == 5)
        {
            skillTitle.text = "SD_LVL1";
            skillDescription.text = "De nouveau choix de dialogues appraissent lorsque vous discutez avec un habitants non péstiféré.";
        }
        else if (skillIndex == 6)
        {
            skillTitle.text = "SD_LVL2";
            skillDescription.text = "Encore plus de nouveau choix de dialogues appraissent lorsque vous discutez avec un habitants non péstiféré.";
        }

        if (skillIndex == 10)
        {
            skillTitle.text = "Folie";
            skillDescription.text = "C'est la branche de la folie.";
        }
        else if (skillIndex == 11)
        {
            skillTitle.text = "FVC_LVL1";
            skillDescription.text = "Vous voyez plus loins dans l'obscurité mais vous êtes plus repoussant envers les habitants.";
        }
        else if (skillIndex == 12)
        {
            skillTitle.text = "FVC_LVL2";
            skillDescription.text = "Vous voyez encore plus loins dans l'obscurité mais vous êtes encore plus repoussant envers les habitants.";
        }
        else if (skillIndex == 13)
        {
            skillTitle.text = "FMP_LVL1";
            skillDescription.text = "Vous vous déplacez plus rapidement mais êtes moins patient lorsque vous discutez avec un habitants.";
        }
        else if (skillIndex == 14)
        {
            skillTitle.text = "FMP_LVL2";
            skillDescription.text = "Vous vous déplacez encore plus rapidement mais êtes encore moins patient lorsque vous discutez avec un habitants.";
        }
        else if (skillIndex == 15)
        {
            skillTitle.text = "FD_LVL1";
            skillDescription.text = "De nouveaux choix de dialogues apparaissent lorsque vous discutez avec un habitants péstiféré.";
        }
        else if (skillIndex == 16)
        {
            skillTitle.text = "FD_LVL2";
            skillDescription.text = "Encore plus de nouveau choix de dialogues apparaissent lorsque vous discutez avec un habitant péstiféré.";
        }
    }

    void ActivateOutlines()
    {
        if (skillIndex == 0)
        {
            sagesseBranch.SetActive(true);
            folieBranch.SetActive(false);

            sagesseOutline.SetActive(true);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        } else if (skillIndex == 1)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(true);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 2)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(true);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 3)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(true);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 4)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(true);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 5)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(true);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 6)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(true);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }

        if(skillIndex == 10)
        {
            sagesseBranch.SetActive(false);
            folieBranch.SetActive(true);

            sagesseOutline.SetActive(false);
            folieOutline.SetActive(true);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 11)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(true);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 12)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(true);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 13)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(true);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 14)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(true);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 15)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(true);
            outline_skill[11].SetActive(false);
        }
        else if (skillIndex == 16)
        {
            sagesseOutline.SetActive(false);
            folieOutline.SetActive(false);

            outline_skill[0].SetActive(false);
            outline_skill[1].SetActive(false);
            outline_skill[2].SetActive(false);
            outline_skill[3].SetActive(false);
            outline_skill[4].SetActive(false);
            outline_skill[5].SetActive(false);

            outline_skill[6].SetActive(false);
            outline_skill[7].SetActive(false);
            outline_skill[8].SetActive(false);
            outline_skill[9].SetActive(false);
            outline_skill[10].SetActive(false);
            outline_skill[11].SetActive(true);
        }
    }
}
