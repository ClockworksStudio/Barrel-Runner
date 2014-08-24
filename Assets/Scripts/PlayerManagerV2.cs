using UnityEngine;
using System.Collections;

public class PlayerManagerV2 : MonoBehaviour
{
	public Animator animator;
	public GameObject explosion;
	static public bool noDamage = false;
	public bool onGround = true;
	public float timer = 0;
	
	// Update is called once per frame
	void Update()
	{
		if((Input.GetKeyDown("space") || PseudoInput.Instance.jumpPressed) && onGround == true)
		{
			timer = 0;
			Jump();
		}
		if(!onGround)
		{
			timer += Time.deltaTime;
			if(timer >= 1)
			{
				onGround = true;
				animator.SetBool("onGround", true);
			}
		}
	}
	void Jump()
	{
		onGround = false;
		animator.SetBool("onGround", false);
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Collision!");
		//Debug.Log ("Player Trigger: " + other.name);
		if(other.name == "Ground")
		{

		}
		if(other.name == "Crayon(Clone)")
		{
			if(!noDamage)
			{
				if(onGround)
				{
					Instantiate(explosion, transform.position, Quaternion.identity);
					Destroy(gameObject);
					Destroy(other.gameObject);
					GameManager.Instance.gameover = true;
				}
			}
			//Debug.Log("Player: You be dead!");
		}
	}
}