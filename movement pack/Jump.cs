using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementPack {
	public class Jump : MonoBehaviour {
		public string objectName;
		public Rigidbody rigidBody;
		public int h;
		private bool _onGround = true;
		
    	private void OnCollisionEnter(Collision col)
    	{
    		if(col.gameObject.name == objectName) {
    			Debug.Log("On ground statement is true.");
    			onornot = false;
    		}
    	}
		
    	private void Update(){
    		if (onGround) {
    			if (Input.GetKey("space")) {
    				rigidBody.AddForce(0, h, 0);
    				onGround = true;
    			}
    		}
    	}
	}
}
