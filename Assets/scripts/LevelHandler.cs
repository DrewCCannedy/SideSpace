using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {
	public static LevelHandler instance;


	void Awake(){
		if(instance)
			DestroyImmediate(gameObject);
		else
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (SceneManager.GetActiveScene().name == "Menu")
				SceneManager.LoadScene ("Main");
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (SceneManager.GetActiveScene().name == "Main")
				SceneManager.LoadScene ("Menu");
		}
	}
}
