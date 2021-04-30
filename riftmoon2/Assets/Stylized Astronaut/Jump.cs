using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour {
    Rigidbody rb;
	private float jumpForce = 1000f;
	private bool onGround;
	
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		onGround = true;
    }
    void Update()
    {
        if (Input.GetButton("Jump") && onGround == true)
        {
			
            rb.velocity = new Vector3( 0f, jumpForce, 0f);
			onGround = false;
        }
    }
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("ground")){
			onGround = true;
		}
	}

}