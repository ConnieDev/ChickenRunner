using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistancePrinter : MonoBehaviour {

	public Text level1Text;
	public Text level2Text;
	public Text level3Text;
	public Text level4Text;
	public Text level5Text;

	// Use this for initialization
	void Start () {
		level1Text.text = GameController.controller.level1Distance + "/" + GameController.controller.level1TotalDistance;
		level2Text.text = GameController.controller.level2Distance + "/" + GameController.controller.level2TotalDistance;
		level3Text.text = GameController.controller.level3Distance + "/" + GameController.controller.level3TotalDistance;
		level4Text.text = GameController.controller.level4Distance + "/" + GameController.controller.level4TotalDistance;
		level5Text.text = GameController.controller.level5Distance + "/" + GameController.controller.level5TotalDistance;
	}
}
