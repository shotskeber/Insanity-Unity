using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IA_Boss_01 : MonoBehaviour {

    #region variables
    [HideInInspector]
    public Transform player;

    public Text textDebug;
    private int p3Transitions = 0;
    public Transform detector;
    //public float detectorYtr;

    public bool isStuned;
    public GameObject stunParticles;

    public bool bossIsRight;
	public Animator boss01_animator;
	public Animator portail_animator;
    public bool playerDetected;
    public bool strongAtk;

    public float mvtSpeed = 0.1f;
    [Space(5)]

    //  waypoints
    public Transform[] waypoints;
    [Space(5)]

    // Boss life
    public int bossHealthPoints = 3;
    public BoxCollider2D bossCol;
    [Space(5)]

    public BossVisibility bossVisibility_script;

    public SpriteRenderer boss01_spr;

    public bool phase_1;
    public bool phase_2;
    public bool phase_3;


    public bool FSMenable;

    #endregion

    #region functions
    // Use this for initialization
    void Start () {
        phase_1 = true;
        FSMenable = true;
        StartCoroutine("Boss01_FSM");
    }

    // Update is called once per frame
    void Update () {
        //DEBUG
        if(phase1_state == State_P1.STUNED || phase2_state == State_P2.STUNED || phase3_state == State_P3.STUNED)
        {
            textDebug.text = "STUNED";
        }
        if (phase1_state == State_P1.PATROL || phase2_state == State_P2.PATROL || phase3_state == State_P3.PATROL)
        {
            textDebug.text = "PATROL";
        }
        if (phase1_state == State_P1.INVESTIGATE || phase2_state == State_P2.INVESTIGATE || phase3_state == State_P3.INVESTIGATE)
        {
            textDebug.text = "INVESTIGATE";
        }
        if (phase1_state == State_P1.CHASE || phase2_state == State_P2.CHASE || phase3_state == State_P3.CHASE)
        {
            textDebug.text = "CHASE";
        }
        if (phase1_state == State_P1.ATTACK || phase2_state == State_P2.ATTACK || phase3_state == State_P3.ATTACK)
        {
            textDebug.text = "ATTACK";
        }
        //DEBUG


        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player.GetComponent<SpriteRenderer>().sortingLayerName == "Platforms")
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        } else
        {
            this.gameObject.GetComponent<Collider2D>().enabled = true;
        }
        if (bossHealthPoints == 2)
        {
            phase1_state = State_P1.DEAD;
        }

        if (bossHealthPoints == 1)
        {
            phase2_state = State_P2.DEAD;
        }

        if (bossHealthPoints == 0)
        {
            phase3_state = State_P3.DEAD;
        }

        if (isStuned)
        {
            stunParticles.SetActive(true);
            if (phase_1)
            {
                phase1_state = State_P1.STUNED;
            }
            else if (phase_2)
            {
                phase2_state = State_P2.STUNED;
            }
            else if (phase_3)
            {
                phase3_state = State_P3.STUNED;
            }
        } else
        {
            stunParticles.SetActive(false);
        }
    }


    void Flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void P3Flip(int dir)
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= dir;
        transform.localScale = theScale;
    }

    //player is in line of sight, increment the detector, if the detector is full, goto chase state
    void Investigate(float sensibility)
    {
        //Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        //Vector3 offset = this.transform.position - player.position;
        //sensibility += 1 / (offset.x);

		if (bossVisibility_script.detectingPlayer)
        {
			detector.GetComponent<Transform>().localScale += new Vector3(0, Time.deltaTime * sensibility, 0);
			//boss01_spr.color = Color.Lerp(Color.white, Color.red, sensibility);
        } else {
            //detectorYtr = 0.1f;
			//boss01_spr.color = Color.white;
            //sensibility = 0f;
			
        }

        if(detector.GetComponent<Transform>().localScale.y > 0.99f) //changer le systeme de détection / boss01_spr.color == new Color(255,6,6,255)
        {
            playerDetected = true;
			if(phase_1){
			phase1_state = State_P1.CHASE;
			detector.GetComponent<Transform>().localScale = new Vector3(3.795496f, 0.1f, 0); //debug
			} else if (phase_2){
			phase2_state = State_P2.CHASE;
			detector.GetComponent<Transform>().localScale = new Vector3(3.795496f, 0.1f, 0); //debug
            } else if (phase_3) {
            phase3_state = State_P3.CHASE;
            detector.GetComponent<Transform>().localScale = new Vector3(3.795496f, 0.1f, 0); //debug
            }
        }
        else
        {
            playerDetected = false;
        }

        if (!bossVisibility_script.detectingPlayer)
        {
            if (phase_1)
            {
                phase1_state = State_P1.PATROL;
            }
            else if (phase_2)
            {
                phase2_state = State_P2.PATROL;
            }
            else if (phase_3)
            {
                phase3_state = State_P3.PATROL;
            }
        }
    }

	//player is detected, goto near him, stop, attack, return to patrol state
    void Chase(int waypointIndexA, int waypointIndexB, float acceleration)
    {
        //Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!bossVisibility_script.detectingPlayer)
        {
            playerDetected = false;
        }

        

        if (playerDetected)
        {
            
            StartCoroutine(Chasecr());
			//StartCoroutine(Attack(0)); //attack coroutine
        } else {
		detector.GetComponent<Transform>().localScale = new Vector3(3.795496f, 0.1f, 0);
			if(phase_1){
			phase1_state = State_P1.INVESTIGATE;
			} else if (phase_2){
			phase2_state = State_P2.INVESTIGATE;
			} else if (phase_3) {
                phase3_state = State_P3.INVESTIGATE;
            }
            /*
            if (Vector2.Distance(transform.position, waypoints[waypointIndexA].position) >= Vector2.Distance(transform.position, waypoints[waypointIndexB].position))
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[waypointIndexA].position.x, transform.position.y, transform.position.z), mvtSpeed);
            }

            if (Vector2.Distance(transform.position, waypoints[waypointIndexA].position) <= Vector2.Distance(transform.position, waypoints[waypointIndexB].position))
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[waypointIndexB].position.x, transform.position.y, transform.position.z), mvtSpeed);
            }
            */
        }
        //phase1_state = State_P1.PATROL;
    }
    #endregion

    #region Boss 01 Finite State Machine
    public IEnumerator Boss01_FSM()
    {
        while (FSMenable) {
        if (phase_1) {
            switch (phase1_state)
            {
                case State_P1.PATROL:
                    if (bossIsRight) {
                            StartCoroutine(GOTO_wpBC(1)); //B1
                            //StartCoroutine("GOTO_wp1B");
                        }
                        else if (!bossIsRight) {
                            StartCoroutine(GOTO_wpAD(0)); //A1
                            //StartCoroutine("GOTO_wp1A");
                        }

                        if (playerDetected)
                        {
                            phase1_state = State_P1.CHASE;
                        } else
                        {
                            phase1_state = State_P1.PATROL;
                        }

                        if (bossVisibility_script.detectingPlayer)
                        {
                            phase1_state = State_P1.INVESTIGATE;
                        }
                        else
                        {
                            phase1_state = State_P1.PATROL;
                        }
                        //Patrol();
                        break;

                case State_P1.CHASE:
                        Chase(0,1,1.25f);
                        //phase1_state = State_P1.PATROL;
                        break;

                case State_P1.INVESTIGATE:
                    Investigate(0.3f); // 1 = super slow
                    break;

                    case State_P1.ATTACK:
                        StartCoroutine(Attack(0));
                        break;

                    case State_P1.DEAD:
                    StartCoroutine("Phase_1_EndingCinematic"); // transition cinematic 1: portail fall
                    break;

                    case State_P1.STUNED:
                        StartCoroutine(Stuned());
                        break;
                }
        }

        if (phase_2)
        {
            switch (phase2_state)
            {
                case State_P2.PATROL:
                        if (bossIsRight)
                        {
                            StartCoroutine(GOTO_wpBC(4)); //B2
                            //StartCoroutine("GOTO_wp2B");
                        }
                        else if (!bossIsRight)
                        {
                            StartCoroutine(GOTO_wpAD(3)); //A2
                            //StartCoroutine("GOTO_wp2A");
                        }
                        //Patrol();
						if (playerDetected)
                        {
                            phase2_state = State_P2.CHASE;
                        } else
                        {
                            phase2_state = State_P2.PATROL;
                        }

                        if (bossVisibility_script.detectingPlayer)
                        {
                            phase2_state = State_P2.INVESTIGATE;
                        }
                        else
                        {
                            phase2_state = State_P2.PATROL;
                        }
                        break;

                case State_P2.CHASE:
					Chase(3,4,1.25f);
                    break;

                case State_P2.INVESTIGATE:
                    Investigate(0.3f);
                    break;

                    case State_P2.ATTACK:
                        StartCoroutine(Attack(0));
                        break;

                    case State_P2.DEAD:
                        StartCoroutine("Phase_2_EndingCinematic"); // transition cinematic 2: manor door fall
                        //Dead();
                        break;

                    case State_P2.STUNED:
                        StartCoroutine(Stuned());
                        break;
                }
        }

            if (phase_3)
            {
                switch (phase3_state)
                {
                    case State_P3.PATROL:

                        //temporary
						if(p3Transitions == 0) {			//goto B
						StartCoroutine(GOTO_wp3BC(8,1, false, -1));
                        }
                        else if (p3Transitions == 1) {	//goto ab
						StartCoroutine(GOTO_wp3BC(7,2, true, -1));
                        }
                        else if (p3Transitions == 2) {	//goto B
						StartCoroutine(GOTO_wp3BC(8,3, false, -1));
                        }
                        else if (p3Transitions == 3) {	//goto C teleportation
						StartCoroutine(GOTO_wp3ADBC(9,4, false, 1));
                        }
                        else if (p3Transitions == 4) {	//goto D 
						StartCoroutine(GOTO_wp3BC(11,5, true, -1));
                        }
                        else if (p3Transitions == 5) {	//goto cd
						StartCoroutine(GOTO_wp3BC(10,6,false,-1));
                        }
                        else if (p3Transitions == 6) {	//goto D
						StartCoroutine(GOTO_wp3BC(11,7,true,-1));
                        }
                        else if (p3Transitions == 7) {	//goto A teleportation
						StartCoroutine(GOTO_wp3ADBC(6,8,true,1));
                        }
                        else if (p3Transitions == 8) {	//goto ab
						StartCoroutine(GOTO_wp3BC(7,0,true,1));    // restart Pattern
                        }

                        if (playerDetected) {
                            phase3_state = State_P3.CHASE;
                        } else {
                            phase3_state = State_P3.PATROL;
                        }

                        if (bossVisibility_script.detectingPlayer) {
                            phase3_state = State_P3.INVESTIGATE;
                        } else {
                            phase3_state = State_P3.PATROL;
                        }
                        break;

                    case State_P3.CHASE:
                        Chase(3, 4, 1.25f);
                        break;

                    case State_P3.INVESTIGATE:
                        Investigate(0.3f);
                        break;

                    case State_P3.ATTACK:
                        StartCoroutine(Attack(0));
                        break;

                    case State_P3.DEAD:
                        StartCoroutine("Phase_3_EndingCinematic"); // transition cinematic 2: manor door fall
                        break;

                    case State_P3.STUNED:
                        StartCoroutine(Stuned());
                        break;
                }
            }
            yield return null;
        }
    }
    #endregion

    #region coroutines
    IEnumerator Stuned()
    {
        bossVisibility_script.enabled = false;
        bossVisibility_script.detectingPlayer = false;
        yield return new WaitForSecondsRealtime(10f);
        bossVisibility_script.enabled = true;
        isStuned = false;
        if (phase_1)
        {
            phase1_state = State_P1.PATROL;
        }
        else if (phase_2)
        {
            phase2_state = State_P2.PATROL;
        }
        else if (phase_3)
        {
            phase3_state = State_P3.PATROL;
        }
        yield return null;
    }

    IEnumerator Chasecr() //go toward player, stop near him, -> ATTACK
    {
        //Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        float chaseDir;
        if (bossIsRight)
        {
            chaseDir = -5f;
        }
        else
        {
            chaseDir = 5f;
        }

        transform.position = Vector3.MoveTowards(transform.position,new Vector3(player.position.x + chaseDir, transform.position.y, transform.position.z), mvtSpeed * 1.25f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (transform.position == new Vector3(player.position.x + chaseDir, transform.position.y, transform.position.z))
        {
            if (phase_1)
            {
                phase1_state = State_P1.ATTACK;
            }
            else if (phase_2)
            {
                phase2_state = State_P2.ATTACK;
            }
            else if (phase_3)
            {
                phase3_state = State_P3.ATTACK;
            }
        }
    
        yield return null;
    }


    //chose beetwen two attack type (slow, strong)
    IEnumerator Attack(int strongAttackOdds)
    {
        //random between two attack option
        float strongAttack = Random.Range(-1f, 1f);

        yield return new WaitForSecondsRealtime(1f);
        if (strongAttack > strongAttackOdds)
        {
            boss01_animator.SetBool("fast_attack", true);
            strongAtk = false;
        } else if (strongAttack < strongAttackOdds)
        {
            strongAtk = true;
            boss01_animator.SetBool("slow_attack", true);
        }
        //Debug.Log("attackAnimation played");
        yield return new WaitForSecondsRealtime(0.5f);
		boss01_animator.SetBool("fast_attack", false);
        boss01_animator.SetBool("slow_attack", false);
		strongAttack = 0f;
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (phase_1){
			phase1_state = State_P1.INVESTIGATE;
			} else if (phase_2){
			phase2_state = State_P2.INVESTIGATE;
            } else if (phase_3){
            phase3_state = State_P3.INVESTIGATE;
            }
        yield return null;
    }


    #region phase 3 coroutines
    //  GOTO waypoint 3A&D
    IEnumerator GOTO_wp3AD(int waypointIndex, int p3Num, bool bossDir, int bossDirFlip) //A1[0] A2[3] A3[6]    D3[11]
    {
        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= 0.1f)
        {
            P3Flip(bossDirFlip);
            bossIsRight = bossDir;
            p3Transitions = p3Num;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[waypointIndex].transform.position.x,
                                                 transform.position.y, transform.position.z), mvtSpeed);
		yield return null;
    }

    //  GOTO waypoint 3B&C
    IEnumerator GOTO_wp3BC(int waypointIndex, int p3Num, bool bossDir, int bossDirFlip) //B1[1] B2[4] B3[8]    C3[9]
    {
        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= 0.1f)
        {
            P3Flip(bossDirFlip);
            bossIsRight = bossDir;
            p3Transitions = p3Num;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[waypointIndex].transform.position.x,
                                                 transform.position.y, transform.position.z), mvtSpeed);
		yield return null;
    }

	    //  GOTO waypoint 3ad & 3bc teleportation
    IEnumerator GOTO_wp3ADBC(int waypointIndex, int p3Num, bool bossDir, int bossDirFlip) //B1[1] B2[4] B3[8]    C3[9]
    {
        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= 0.1f)
        {
            P3Flip(bossDirFlip);
            bossIsRight = bossDir;
            p3Transitions = p3Num;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        transform.position = new Vector3(waypoints[waypointIndex].transform.position.x,
                                         waypoints[waypointIndex].transform.position.y, waypoints[waypointIndex].transform.position.z);
		yield return null;
    }

    //  phase3
    IEnumerator Phase_3_EndingCinematic()
    {
        bossVisibility_script.enabled = false;
        bossVisibility_script.detectingPlayer = false;
        Debug.Log("Boss 01 is defeted.");
        yield return null;
    }

    #endregion


    //  GOTO waypoint A&D
    IEnumerator GOTO_wpAD(int waypointIndex) //A1[0] A2[3] A3[6]    D3[11]
    {
        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= 0.1f)
        {
            Flip();
            bossIsRight = true;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[waypointIndex].transform.position.x,
                                                 transform.position.y, transform.position.z), mvtSpeed);
        yield return null;
    }

    //  GOTO waypoint B&C
    IEnumerator GOTO_wpBC(int waypointIndex) //B1[1] B2[4] B3[8]    C3[9]
    {
        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= 0.1f)
        {
            Flip();
            bossIsRight = false;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[waypointIndex].transform.position.x,
                                                 transform.position.y, transform.position.z), mvtSpeed);
        yield return null;
    }

    //  Transition 1 Cinematic
    IEnumerator Phase_1_EndingCinematic()
    {
        bossVisibility_script.enabled = false;
        bossVisibility_script.detectingPlayer = false;
        bossCol.enabled = false;
        //bossIsRight = true;
        if (!bossIsRight)
        {
            bossIsRight = true;
            Flip();
        }
        yield return new WaitForSecondsRealtime(1f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[2].transform.position.x, 
                                                 transform.position.y, transform.position.z), mvtSpeed);
		yield return new WaitForSecondsRealtime(0.5f);
		portail_animator.SetBool("portail1Fall", true);
        yield return new WaitForSecondsRealtime(2f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[4].transform.position.x, 
                                                 transform.position.y, transform.position.z), mvtSpeed);
        phase_1 = false;
        phase_2 = true;
        bossVisibility_script.enabled = true;
        bossCol.enabled = true;
        Debug.Log("Transition to phase 2.");
        yield return null;
    }

    //  Transition 2 Cinematic
    IEnumerator Phase_2_EndingCinematic()
    {
        bossVisibility_script.enabled = false;
        bossVisibility_script.detectingPlayer = false;
        bossCol.enabled = false;
        //bossIsRight = true;
        if (!bossIsRight)
        {
            bossIsRight = true;
            Flip();
        }
        yield return new WaitForSecondsRealtime(1f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[5].transform.position.x,
                                                 transform.position.y, transform.position.z), mvtSpeed);
        yield return new WaitForSecondsRealtime(0.5f);
        portail_animator.SetBool("portail2Fall", true);
        yield return new WaitForSecondsRealtime(2f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waypoints[8].transform.position.x,
                                                 transform.position.y, transform.position.z), mvtSpeed);
        phase_2 = false;
        phase_3 = true;
        bossVisibility_script.enabled = true;
        bossCol.enabled = true;
        Debug.Log("Transition to phase 3.");
        yield return null;
    }


    #endregion

    #region phases states
    public State_P1 phase1_state;
    public enum State_P1
    {
        PATROL,
        CHASE,
        ATTACK,
        INVESTIGATE,
        STUNED,
        DEAD,
    }

    public State_P2 phase2_state;
    public enum State_P2
    {
        DISABLE,
        PATROL,
        CHASE,
        ATTACK,
        INVESTIGATE,
        STUNED,
        DEAD
    }

    public State_P3 phase3_state;
    public enum State_P3
    {
        DISABLE,
        PATROL,
        CHASE,
        ATTACK,
        INVESTIGATE,
        STUNED,
        DEAD
    }
    #endregion
}
