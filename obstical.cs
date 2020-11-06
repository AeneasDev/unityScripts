using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstical : MonoBehaviour
{
    public Rigidbody rb;
    public int s;
    int correction = 1;
    void Start()
    {
	        
    }

    // Update is called once per frame
    IEnumerator Move()
    {
        rb.AddRelativeForce(Vector3.left * s);

       	yield return new WaitForSeconds(1);
       	rb.AddRelativeForce(Vector3.left * s);
        rb.AddRelativeForce(Vector3.right * s * 2);
        yield return new WaitForSeconds(1);
	}
	void Update()
	{
		StartCoroutine(Move());
	}
}
