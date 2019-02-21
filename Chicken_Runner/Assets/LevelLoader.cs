using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	public void SwichScene(string name){
		SceneManager.LoadScene (name);
		GameController.controller.isPaused = false;
	}

}
