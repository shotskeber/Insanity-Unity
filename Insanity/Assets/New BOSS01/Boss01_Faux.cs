using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01_Faux : MonoBehaviour
{
    public GameObject bossTr;       //Public variable to store a reference to the player game object
    public IA_Boss_01 isBossScript;
    public Player_Health_Boss01 playerhealthScript;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //this.transform.localScale = new Vector3(1, 1, 1);
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - bossTr.transform.position;
        isBossScript = isBossScript.GetComponent<IA_Boss_01>();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = bossTr.transform.position + offset;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerhealthScript.playerHealth -= 1;
            Debug.Log("Player" + "-1");
        }
    }

    void Update()
    {
        if (isBossScript.bossIsRight)
        {
            Vector2 theScale = transform.localScale;
            theScale.x = -0.3638155f;
            transform.localScale = theScale;
        }
        else
        {
            Vector2 theScale = transform.localScale;
            theScale.x = 0.3638155f;
            transform.localScale = theScale;
        }
    }
}