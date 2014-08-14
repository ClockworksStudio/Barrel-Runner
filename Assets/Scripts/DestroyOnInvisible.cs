using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour {

	// Use this for initialization
	void OnBecameInvisible()
	{
		if(!GameManager.Instance.gameover)
		{
			GameManager.Instance.score += 10;
		}
		Destroy(gameObject);
	}
}
