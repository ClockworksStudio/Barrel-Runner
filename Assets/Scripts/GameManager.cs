using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance
	{
		get
		{
			if(_instance != null)
			{
				return _instance;
			}
			else
			{
				GameObject gameManager = new GameObject("GameManager");
				_instance = gameManager.AddComponent<GameManager>();
				return _instance;
			}
		}
	}

	private static GameManager _instance;

	public int score = 0;

	// Use this for initialization
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
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void OnGUI()
	{
		GUILayout.Label("Score: "+score.ToString());
	}
}
