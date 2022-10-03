using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour {

	Rigidbody rb;
	public Animator anim;
 
	public bool canMove;
	[SerializeField] float moveSpeed;
	//[SerializeField] float maxSpeed;
	Vector3 moveDir;


    void Start() {
        rb = GetComponent<Rigidbody>();

		canMove = false;
		///canMove = true;
    }

   

    void Update() {
		if (canMove && moveDir != Vector3.zero) {
			transform.LookAt(transform.position + moveDir);
			//rb.AddForce(Vector2.right * moveDir.x * moveSpeed);
			rb.position += moveDir * moveSpeed * Time.deltaTime;
			anim.SetBool("Walking", true);

		}
		else {
			//Maybe not necessary?
			rb.position = transform.position;
			anim.SetBool("Walking", false);
		}

		//Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
    }


	void OnMove (InputValue btn) {
		float btnValHor = btn.Get<Vector2>().x;
		float btnValVert = btn.Get<Vector2>().y;

		//if (btn.isPressed) {

			moveDir = new Vector3(btnValHor, 0f, btnValVert);
			//if (btnVal > 0.05f || btnVal < -0.05f) {
			//}

		//}
		//else {
		//	moveDir = Vector2.zero;
		//}
		
		print(moveDir);

	}


}
