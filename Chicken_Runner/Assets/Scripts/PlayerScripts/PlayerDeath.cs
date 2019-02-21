using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {
	private Rigidbody2D myRigidbody;
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private LayerMask whatIsBadGround;
	[SerializeField]
	private float groundRadius;
	private bool isDead;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		isDead = IsDead ();
		if(transform.position.y < -12 || isDead){
			PlayerDie ();
		}
	}

	void PlayerDie(){
		if(this.GetComponent<RecordDistance> ().distance > GameController.controller.level1Distance){
			GameController.controller.level1Distance = this.GetComponent<RecordDistance> ().distance;
		}
		SceneManager.LoadScene (GameController.controller.scene);
	}

	private bool IsDead(){
		if(myRigidbody.velocity.y <= 0){
			foreach(Transform point in groundPoints){
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsBadGround);
				for(int i = 0; i < colliders.Length; i++){
					if(colliders[i].gameObject != gameObject){
						return true;
					}
				}
			}
		}
		return false;
	}
}
