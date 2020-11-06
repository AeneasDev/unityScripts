using UnityEngine;

namespace MovementPack {
	public class PlayerMovementMaster : MonoBehaviour {
		public Transform trans;
		public Rigidbody rigidBody;
		public int movementSpeed;
		public int rotationSpeed;
		public int jumpHeight;
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

		private void Update() {
			if (Input.GetKey(KeyCode.A)){
				trans.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
			}
			
			if (Input.GetKey(KeyCode.D)){
				trans.Rotate(0, rotationSpeed * Time.deltaTime, 0);
			}
			
			if (Input.GetKey(KeyCode.W)){
				rigidBody.AddRelativeForce(Vector3.forward * movementSpeed);
			}
			
			if (Input.GetKey(KeyCode.S)){
				rigidBody.AddRelativeForce(-Vector3.forward * movementSpeed);
			}
			
			if (isGrounded){
				if (Input.GetKey(KeyCode.Space)) {
					rigidBody.AddForce(0, h, 0);
					
					isGrounded = true;
				}
			}
				
			if (!isGrounded){
			        trans.Rotate(0, 100, 0);
			}
		}
	}
}
