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
	#endregion
	#region Unity Methods
    void Start()
    {
        _isAlive = true;
        Xrotation = transform.rotation.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        _isGrounded = Physics.CheckSphere(groundcheckBase.position, groundCheckRadius, groundLayer);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    #endregion
}
