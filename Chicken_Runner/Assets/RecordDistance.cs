using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordDistance : MonoBehaviour {

	public int distance;
	public Text distanceText;
	public Text highDistanceText;

	// Use this for initialization
	void Start () {
		highDistanceText.text = "Farthest run: " + GameController.controller.level1Distance + " feet";

	}
	
	// Update is called once per frame
	void Update () {
		distance = (int)transform.position.x;
		distanceText.text = "Distance: " + distance + " feet";
	}
}
