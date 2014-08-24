using UnityEngine;
using System.Collections;

public class DestroyOnInvisibleAndPlaySound : MonoBehaviour
{
	void OnBecameInvisible()
	{
		if(!GameManager.Instance.gameover)
		{
			GameManager.Instance.addScore();
		}
		Destroy(gameObject);
	}
}
