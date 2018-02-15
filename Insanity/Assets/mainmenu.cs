using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void Playgame ()
    {
        SceneManager.LoadScene(12);
    }

    public void QuitGame ()
    {
        Application.Quit(); 
    }
}
