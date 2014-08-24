﻿using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public GameObject explosion;
	public float jumpSpeed = 300.0f;
	static public bool noDamage = false;
	static public bool onGround = true;

	// Update is called once per frame
	void Update()
	{
		if((Input.GetKeyDown("space") || PseudoInput.Instance.jumpPressed) && onGround == true)
		{
			Jump();
		}
	}
	void Jump()
	{
		rigidbody.AddForce(Vector3.up * jumpSpeed);
		onGround = false;
	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("Player Trigger: " + other.name);
		if(other.name == "Ground")
		{
			onGround = true;
		}
		if(other.name == "Crayon(Clone)")
		{
			if(!noDamage)
			{
				Instantiate(explosion, transform.position, Quaternion.identity);
				Destroy(gameObject);
				Destroy(other.gameObject);
				GameManager.Instance.gameover = true;
			}
			//Debug.Log("Player: You be dead!");
		}
	}
}