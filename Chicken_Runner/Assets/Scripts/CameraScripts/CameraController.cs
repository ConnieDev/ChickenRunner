using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField]
	private float xMax;

	[SerializeField]
	private float xMin;

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Chicken").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp(target.position.x,xMin,xMax),transform.position.y,transform.position.z);
	}
}
