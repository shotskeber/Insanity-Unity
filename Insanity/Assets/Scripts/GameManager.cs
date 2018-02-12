using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

	public int currentTime = 700;
	public bool isTalking = false;
    public int heldItem = 0;
    public float lightGeneralInt = 1f;
    public float lightNightInt = 0f;

    //Awake is always called before any Start functions
    void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}


    void Start()
    {
       /* Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
    }

	//Update is called every frame.
	void Update()
	{

	}

	void OnApplicationQuit()
	{
		if (GameManager.instance != null)
			Destroy (GameManager.instance);
		PlayerPrefs.DeleteAll();
	}
}
