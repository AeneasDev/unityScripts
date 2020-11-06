using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementPack {
	public class PlayerMovementMaster : MonoBehaviour {
		public Transform t;
		public Rigidbody rb;
		public int movementSpeed;
		public int rotationSpeed;
		public int h;
		public bool isGrounded;
		
		private void OnCollisionEnter(Collision collision){
			if (collision.gameObject.layer == 0 && !isGrounded) {
				isGrounded = true;
			}
		}
		
		private void OnCollisionExit(Collision collision){
			if (collision.gameObject.layer == 0 && isGrounded) {
				isGrounded = false;
			}
		}

		void Update() {
			if (Input.GetKey(KeyCode.A)){
				t.Rotate(0, -rSpeed * Time.deltaTime, 0);
			}
			
			if (Input.GetKey(KeyCode.D)){
				t.Rotate(0, rSpeed * Time.deltaTime, 0);
			}
			
			if (Input.GetKey(KeyCode.W)){
				rb.AddRelativeForce(Vector3.forward * mSpeed);
			}
			
			if (Input.GetKey(KeyCode.S)){
				rb.AddRelativeForce(-Vector3.forward * mSpeed);
			}
			
			if (isGrounded){
				if (Input.GetKey(KeyCode.Space)) {
					rb.AddForce(0, h, 0);
					
					isGrounded = true;
				}
			}
				
			if (!isGrounded){
					t.Rotate(0, 100, 0);
			}
		}
	}
}
