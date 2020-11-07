using UnityEngine;

namespace MovementPack {
	public class PlayerMovementMaster : MonoBehaviour {
		#region Properties
		
		public Transform trans;
		public Rigidbody rigidBody;
		public int movementSpeed;
		public int rotationSpeed;
		public int jumpHeight;
		
		public GameObject checkpoint;
		
		#endregion
		
		#region Player Stats
		
		private bool _isGrounded;
		private bool _isAlive;
		
		#endregion
			
		private void Start() {
			_isAlive = true;
		}
		
		private void OnCollisionEnter(Collision other){
			if (other.gameObject.layer == 0 && !isGrounded) {
				_isGrounded = true;
			}
			
			if (other.gameObject.CompareTag("Obstacle")) {
				_isAlive = false;
				
				gameObject.transform.position = checkpoint.transform.position;
			}
		}
		
		private void OnCollisionExit(Collision other){
			if (other.gameObject.layer == 0 && isGrounded) {
				_isGrounded = false;
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
