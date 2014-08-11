using UnityEngine;
using System.Collections;

public class BasicJump : MonoBehaviour
{
	public float jumpSpeed = 300.0f;

	private bool onGround = true;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
		{
			Jump();
		}
	}
	void Jump()
	{
		rigidbody.AddForce(Vector3.up * jumpSpeed);
		onGround = false;
	}
	void OnTriggerEnter()
	{
		onGround = true;
	}
}