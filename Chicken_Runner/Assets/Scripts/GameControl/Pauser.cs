using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour {

	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TogglePause(){
		if(GameController.controller.isPaused){
			GameController.controller.isPaused = false;
			pauseMenu.SetActive (false);
		}else if(!GameController.controller.isPaused){
			GameController.controller.isPaused = true;
			pauseMenu.SetActive (true);
		}
	}
}
