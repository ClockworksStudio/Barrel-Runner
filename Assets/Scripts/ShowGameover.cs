using UnityEngine;
using System.Collections;

public class ShowGameover : MonoBehaviour
{
	void Update()
	{
		if(GameManager.Instance.gameover)
		{
			renderer.enabled = true;
		}
		else
		{
			renderer.enabled = false;
		}
	}
}
