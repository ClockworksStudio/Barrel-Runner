using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
	public List<string> deathList = new List<string>();
	public Animator animator;
	public GameObject explosion;
	static public bool noDamage = false;
	public static bool onGround = true;
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
		foreach(string str in deathList)
		{
			if(other.name == str)
			{
				if(!noDamage)
				{
					Instantiate(explosion, transform.position, Quaternion.identity);
					Destroy(gameObject);
					Destroy(other.transform.parent.gameObject);
					GameManager.Instance.gameover = true;
				}
				break;
			}
		}
	}
}