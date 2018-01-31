using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class Player_Health_Boss01 : MonoBehaviour
{

    public PostProcessingProfile m_Profile;
    public int playerHealth = 5;
    public bool playerIsAlive = true;

    void Start()
    {
        var behaviour = GetComponent<PostProcessingBehaviour>();
        /*
        if (behaviour.profile == null)
        {
            enabled = false;
            return;
        }
        */
        //m_Profile = Instantiate(behaviour.profile);
        //behaviour.profile = m_Profile;
    }

    void Update()
    {


        var vignette = m_Profile.vignette.settings;

        if (playerHealth == 5)
        {

            vignette.smoothness = 0.5f;
            m_Profile.vignette.settings = vignette;
        }
        else if (playerHealth == 4)
        {
            vignette.smoothness = 0.6f;
            m_Profile.vignette.settings = vignette;
        }
        else if (playerHealth == 3)
        {
            vignette.smoothness = 0.7f;
            m_Profile.vignette.settings = vignette;
        }
        else if (playerHealth == 2)
        {
            vignette.smoothness = 0.8f;
            m_Profile.vignette.settings = vignette;
        }
        else if (playerHealth == 1)
        {
            vignette.smoothness = 0.9f;
            m_Profile.vignette.settings = vignette;
        }
        else if (playerHealth == 0)
        {
            vignette.smoothness = 0.95f;
            m_Profile.vignette.settings = vignette;
            playerIsAlive = false;
            Application.LoadLevel(Application.loadedLevel);
        }

        //Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup) * 0.99f) + 0.01f;
    }
}
