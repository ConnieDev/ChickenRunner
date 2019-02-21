using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	private Rigidbody2D myRigidbody;
	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private Transform[] facePoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;
	private bool isGrounded;
	private bool isFree;
	private bool jump;
	[SerializeField]
	private float jumpForce;
	public Sprite jumpImage;
	
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController.controller.isPaused) {
			myRigidbody.gravityScale = 5;
			isGrounded = IsGrounded ();
			isFree = IsFree ();
			MoveRight ();
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
				if (Input.GetTouch (0).position.y < 600) {
					Jump ();
					this.GetComponent<SpriteRenderer> ().sprite = jumpImage;
				}
			}
		} else {
			myRigidbody.velocity = new Vector2 (0, 0);
			myRigidbody.gravityScale = 0;
		}
	}

	private void MoveRight(){
		if (!GameController.controller.isPaused) {
			if (isFree) {
				myRigidbody.velocity = new Vector2 (movementSpeed, myRigidbody.velocity.y);
			}
		}
	}
	private void Jump(){
		if (!GameController.controller.isPaused) {
			jump = true;
			if (isGrounded && jump) {
				
				isGrounded = false;
				jump = false;
				myRigidbody.AddForce (new Vector2 (0, jumpForce));
			}
		}
	}

	private bool IsGrounded(){
		if(myRigidbody.velocity.y <= 0){
			foreach(Transform point in groundPoints){
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for(int i = 0; i < colliders.Length; i++){
					if(colliders[i].gameObject != gameObject){
						myRigidbody.velocity.Set (myRigidbody.velocity.x, 0f);
						return true;
					}
				}
			}
		}
		return false;
	}
	private bool IsFree(){
		if (myRigidbody.velocity.x <= 0) {
			foreach (Transform point in facePoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return false;
					}
				}
			}
		}
		return true;
	}
}
