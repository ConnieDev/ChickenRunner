using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour {
	// Public variables
	public RectTransform panel; // To hold th ScrollPanel
	public Button[] bttn;
	public RectTransform center; // Center to compare the distance for each button
	// private variables
	private float[] distance; // all buttons' distance to the center
	private float[] distReposition;
	private bool dragging = false;  // will Behaviour true while WebCamFlags drag the panel
	private int bttnDistance; // will hold the distance between the buttons
	private int minButtonNum;  // to hold the number of the button, with smallest distance to center
	private int bttnLength;
	private bool targetNearestButton = true;

	void Start(){
		bttnLength = bttn.Length;
		distance = new float[bttnLength];
		distReposition = new float[bttnLength];

		// get distance between buttons 
		bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
	}
	void Update(){
		for (int i = 0; i < bttn.Length; i++) {
			distReposition[i] = center.GetComponent<RectTransform> ().position.x - bttn [i].GetComponent<RectTransform> ().position.x;
			distance [i] = Mathf.Abs (distReposition[i]);

			if(distReposition[i] > 2000){
				float curX = bttn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = bttn [i].GetComponent<RectTransform> ().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX + (bttnLength * bttnDistance), curY);
				bttn [i].GetComponent<RectTransform> ().anchoredPosition = newAnchoredPos;
			}
			if(distReposition[i] < -2000){
				float curX = bttn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = bttn [i].GetComponent<RectTransform> ().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX - (bttnLength * bttnDistance), curY);
				bttn [i].GetComponent<RectTransform> ().anchoredPosition = newAnchoredPos;
			}
		}
		if(targetNearestButton){
			float minDistance = Mathf.Min (distance); // get the min distance

			for (int a = 0; a < bttn.Length; a++) {
				if(minDistance == distance[a]){
					minButtonNum = a;
				}
			}
		}
		if(!dragging){
			LerpToBttn (-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
		}
	}

	void LerpToBttn(float position){
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;
	}
	public void StartDrag(){
		dragging = true;
		targetNearestButton = true;
	}

	public void EndDrag(){
		dragging = false;
	}
	public void GoToButton(int buttonIndex){
		targetNearestButton = false;
		minButtonNum = buttonIndex - 1;
	}

	public void GoToNext(){
		targetNearestButton = false;
		if (minButtonNum < bttnLength-1) {
			minButtonNum += 1;
		} else {
			minButtonNum = 0;
		}
	}
	public void GoToLast(){
		targetNearestButton = false;
		if (minButtonNum > 0) {
			minButtonNum -= 1;
		} else {
			minButtonNum = bttnLength-1;
		}
	}
}
