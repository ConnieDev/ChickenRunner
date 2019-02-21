using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public static GameController controller;
	public bool isPaused;
	public Scene currentScene;
	public string scene;
	public int level1Distance;
	public int level2Distance;
	public int level3Distance;
	public int level4Distance;
	public int level5Distance;
	public int level1TotalDistance = 220;
	public int level2TotalDistance;
	public int level3TotalDistance;
	public int level4TotalDistance;
	public int level5TotalDistance;

	void Awake(){
		if (controller == null) {
			DontDestroyOnLoad (gameObject);
			controller = this;
		}else if(controller != this){
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		currentScene = SceneManager.GetActiveScene ();
		scene = currentScene.name;
	}

	public void Quit(){
		Application.Quit ();
	}
}
