using UnityEngine;
using System.Collections;

public class PersistingGameobject : MonoBehaviour
{
	public static PersistingGameobject Instance
	{
		get
		{
			return _instance;
		}
	}
	private static PersistingGameobject _instance;

	// Use this for initialization
	void Start ()
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
