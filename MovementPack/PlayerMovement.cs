using UnityEngine;

namespace MovementPack {
	public class PlayerMovement : MonoBehaviour {
		#region Variables and Properties

	    private bool _isGrounded;
	    private bool _isAlive;
	    private float _xRotation;
		private float _yRotation;

	    [Header("Ground check parameters")]
	    [SerializeField] private Transform _groundcheckBase;
	    [SerializeField] private float _groundCheckRadius = 0.2f;
	    [SerializeField] private LayerMask _groundLayer;
	    [Space(5)]

	    [Header("Mouse Look")]
	    [SerializeField] private float _mouseLookSensitivity = 10f;


		#endregion
			
		#region Unity Methods
			
	    private void Start() {
			Transform trans = transform;
			
		    _isAlive = true;
		    _xRotation = trans.rotation.y;
		    _yRotation = trans.rotation.x;
		    Cursor.lockState = CursorLockMode.Locked;
	    }

	    // Update is called once per frame
	    private void Update() {
		    // Ground check
		    _isGrounded = Physics.CheckSphere(_groundcheckBase.position, _groundCheckRadius, _groundLayer);
		    // Mouselook
		    _xRotation += Input.GetAxis("Mouse X");

		    transform.rotation = Quaternion.Euler(_yRotation, _xRotation, transform.rotation.z);
	    }
		
		#endregion
	}
}
