using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public float jumpSpeed = 300.0f;
	static public bool noDamage = false;
	private bool onGround = true;
	public bool gameover = false;

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
				Destroy(gameObject);
				GameManager.Instance.gameover = true;
			}
			//Debug.Log("Player: You be dead!");
		}
	}
}