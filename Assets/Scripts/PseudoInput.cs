using UnityEngine;
using System.Collections;

public class PseudoInput : MonoBehaviour
{
	public static PseudoInput Instance
	{
		get
		{
			return _instance;
		}
	}
	
	private static PseudoInput _instance;
	
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
}
