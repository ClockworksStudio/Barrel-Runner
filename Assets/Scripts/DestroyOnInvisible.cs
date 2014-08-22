using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour
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
