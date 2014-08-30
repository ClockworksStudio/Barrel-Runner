using UnityEngine;
using System.Collections;

public class PseudoInputOnTouch : MonoBehaviour
{
	public static PseudoInputOnTouch Instance
	{
		get
		{
			return _instance;
		}
	}
	
	private static PseudoInputOnTouch _instance;
	
	[HideInInspector]
	public bool jumpPressed = false;
	
	void Start()
	{
		if(_instance != this)
		{
			if(_instance == null)
			{
				_instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
		DontDestroyOnLoad(gameObject);
	}
	void OnTouchDown()
	{
		if(GameManager.Instance.gameover)
		{
			GameManager.Instance.SendMessage("RestartGame");
		}
		else
		{
			jumpPressed = true;
		}
	}
	void OnTouchUp()
	{
		jumpPressed = false;
	}
}