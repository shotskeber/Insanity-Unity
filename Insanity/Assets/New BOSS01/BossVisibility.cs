using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVisibility : MonoBehaviour
{

    [Range(0f, 50f)]
    public int distanceToSee;

    //public bool playerDetected;
    public bool detectingPlayer;



    public SpriteRenderer boss01_spr;
    public IA_Boss_01 ia_boss_script;
    int rayDir;
    RaycastHit2D hit;

    // Use this for initialization
    void Start()
    {
        //boss01_spr = this.gameObject.GetComponent<SpriteRenderer>();
        //ia_boss_script = this.gameObject.GetComponent<IA_Boss_01>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sortingLayerName == "Platforms")
        {
            detectingPlayer = false;
        }

        Vector2 direction = new Vector2(1, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction * rayDir, distanceToSee);


        if (ia_boss_script.GetComponent<IA_Boss_01>().bossIsRight)
        {
            rayDir = 1;
        }
        else
        {
            rayDir = -1;
        }

        Debug.DrawRay(this.transform.position, direction * rayDir * distanceToSee, Color.magenta);
        if (Physics2D.Raycast(this.transform.position, direction * rayDir, distanceToSee))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    if(GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sortingLayerName == "Player")
                    {
                        detectingPlayer = true;
                    }
                    //boss01_spr.color = Color.red;
                    //playerDetected = true;
					//Debug.Log("Player touched");
                }
            }
        }
        else
        {
            boss01_spr.color = Color.white;
            //playerDetected = false;
            detectingPlayer = false;
        }
    }


}
