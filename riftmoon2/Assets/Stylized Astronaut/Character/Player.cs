using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 900.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;
		private Rigidbody rb;
		public LayerMask groundLayers;
		public float jumpForce = 100;
		private float verticalVelocity;
		
		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
			
		}

		void Update (){
			
			if (Input.GetKey ("w")) {
				anim.SetInteger ("AnimationPar", 1);
			}  
			
			else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
				
			}
			
			if (Input.GetKeyDown (KeyCode.Space)) {
					
                verticalVelocity = jumpForce;
				//controller.Move (jumpVector * Time.deltaTime);

           }
			Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= -verticalVelocity + gravity * Time.deltaTime;

		}
}
