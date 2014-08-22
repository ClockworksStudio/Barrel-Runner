using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance
	{
		get{return _instance;}
//		get
//		{
//			if(_instance != null)
//			{
//				return _instance;
//			}
//			else
//			{
//				GameObject gameManager = new GameObject("GameManager");
//				_instance = gameManager.AddComponent<GameManager>();
//				return _instance;
//			}
//		}
	}
	public string menuLevel;

	private static GameManager _instance;

	[HideInInspector]
	public int score = 0;
	[HideInInspector]
	public bool gameover = false;

	// Use this for initialization
	void Start()
	{
		if(_instance != this)
		{
//			if(_instance == null)
//			{
				_instance = this;
			}
//			else
//			{
//				Destroy(gameObject);
//			}
//		}
		//DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.anyKeyDown && gameover)
		{
			RestartGame();
		}
	}

	void RestartGame()
	{
		score = 0;
		gameover = false;
		Application.LoadLevel(menuLevel);
	}
	void OnGUI()
	{
		GUILayout.Label("Score: "+score.ToString());
		if(gameover)
		{
			GUILayout.Label("Game Over!");
			GUILayout.Label("Touch anywhere or press any key to continue.");
		}
	}
}
