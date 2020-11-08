using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables and Properties
    private bool _isGrounded;
    private bool _isAlive;
    private float Xrotation;
    private float Yrotation;
    [Header("Ground check parameters")]
    [SerializeField] private Transform groundcheckBase;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [Space(5)]
    [Header("Mouse Look")]
    [SerializeField] private float mouseLookSensitivity = 10f;


	#endregion
	#region Unity Methods
    void Start()
    {
        _isAlive = true;
        Xrotation = transform.rotation.y;
        Yrotation = transform.rotation.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        _isGrounded = Physics.CheckSphere(groundcheckBase.position, groundCheckRadius, groundLayer);
        //Mouselook
        Xrotation += Input.GetAxis("Mouse X");

        transform.rotation = Quaternion.Euler(Yrotation, Xrotation, transform.rotation.z);
    }
	#endregion
}
