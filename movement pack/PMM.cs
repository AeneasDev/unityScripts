using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMM : MonoBehaviour
{




	public Transform t;
	public Rigidbody rb;
	public int mSpeed;
	public int rSpeed;
	public int h;
	int onornot = 0;
    // Start is called before the first frame update
    public bool isGrounded;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0 && !isGrounded){
            isGrounded = true;
            onornot = 1;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 0 && isGrounded){
            isGrounded = false;
            onornot = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")){
        	t.Rotate(0, -rSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("d")){
        	t.Rotate(0, rSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("w")){
        	rb.AddRelativeForce(Vector3.forward * mSpeed);
        }
        if (Input.GetKey("s")){
        	rb.AddRelativeForce(-Vector3.forward * mSpeed);
        }
        if (isGrounded == true){
    		if (Input.GetKey("space")){
    			rb.AddForce(0, h, 0);
    			onornot = 0;
    		}
    	if (isGrounded == false){
    			t.Rotate(0, 100, 0);
    			
    	}
        }
    }
}

