using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpLoader : MonoBehaviour {

	public GameObject helpScreen;

	public void ToggleScreen(){
		if(helpScreen.activeSelf == false){
			helpScreen.SetActive (true);
		}else if(helpScreen.activeSelf == true){
			helpScreen.SetActive (false);
		}
	}

}
