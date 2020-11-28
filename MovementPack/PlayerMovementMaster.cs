using UnityEngine;

namespace MovementPack {
    public class PlayerMovementMaster : MonoBehaviour {
        #region Properties
        //Sets up stuff
        
        public Rigidbody rigidBody;
        public int movementSpeed;
        public int runSpeed;
        public int jumpHeight;
        public string enemieTag = "Obstacle";
        public GameObject checkpoint;
        bool _run;
        #endregion
        
        #region Player Stats
        
        private bool _isGrounded;
        
        
        #endregion
            
        
        
        #region Movemnt
        
        private void OnCollisionEnter(Collision other){
            if (other.gameObject.layer == 0 && !_isGrounded) {
                _isGrounded = true;
            }
            
            if (other.gameObject.CompareTag(enemieTag)) {
                
                
                gameObject.transform.position = checkpoint.transform.position;
            }
        }
        
        private void OnCollisionExit(Collision other){
            if (other.gameObject.layer == 0 && _isGrounded) {
                _isGrounded = false;
            }
        }

        private void Update() {
        	//regular ol basic walk
            if (Input.GetKey(KeyCode.A)){
                rigidBody.AddRelativeForce(Vector3.left * movementSpeed * Time.deltaTime);
                //S P E E D
                if (Input.GetKey(KeyCode.E)){
                	rigidBody.AddRelativeForce(Vector3.left * runSpeed * Time.deltaTime);
                }
            }
            
            if (Input.GetKey(KeyCode.D)){
                rigidBody.AddRelativeForce(Vector3.right * movementSpeed * Time.deltaTime);
                if (Input.GetKey(KeyCode.E)){
                	rigidBody.AddRelativeForce(Vector3.right * runSpeed * Time.deltaTime);
                }
            }
            
            if (Input.GetKey(KeyCode.W)){
            	rigidBody.AddRelativeForce(Vector3.forward * movementSpeed * Time.deltaTime);
                if (Input.GetKey(KeyCode.E)){
                	rigidBody.AddRelativeForce(Vector3.forward * runSpeed * Time.deltaTime);
                }
            }
            
            if (Input.GetKey(KeyCode.S)){
                rigidBody.AddRelativeForce(Vector3.back * movementSpeed * Time.deltaTime);
                if (Input.GetKey(KeyCode.E)){
                	rigidBody.AddRelativeForce(Vector3.back * runSpeed * Time.deltaTime);
                }
            }
            #endregion

            if (_isGrounded){
                if (Input.GetKey(KeyCode.Space)) {
                    if (rigidBody.velocity.y < 1)
                    {
                        rigidBody.AddForce(0, jumpHeight, 0);
                    }
                    _isGrounded = true;	
                }
            }
        }
    }
}
