using UnityEngine;
using System.Collections;

public class AnimatorScript : MonoBehaviour
{
	public Animator animator;
	public bool onGround = PlayerManager.onGround;
	// Use this for initialization
	void Start ()
	{
		//animator = GetComponent(Animator);
	}

	void Update()
	{
		onGround = PlayerManager.onGround;
	}

	void FixedUpdate()
	{
		animator.SetBool("onGround", onGround);
	}
}
