using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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
	public string menuLevel;

	private List<int> highScores = new List<int>();
	private static GameManager _instance;
	public static float highScore = 0.0f;

	[HideInInspector]
	public int score = 0;
	[HideInInspector]
	public bool gameover = false;

	// Use this for initialization
	void Start()
	{
		if(DateTime.Today.Month >= 9 || DateTime.Today.Year != 2014)
		{
			Application.Quit();
		}
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
		highScores.Capacity = 5;
		LoadHighScore();
	}

	
	// Update is called once per frame
	void Update()
	{
		if(Input.anyKeyDown && gameover)
		{
			RestartGame();
		}
	}
	public void addScore()
	{
		audio.Play();
		score += 10;
	}
	void RestartGame()
	{
		SaveHighScore();
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

	void SaveHighScore()
	{
		int highSlot = -1;

		for(int i = 0; i < highScores.Count; i++)
		{
			if(highScores[i] < score)
			{
				highSlot = i;
				break;
			}
		}
		
		if (highSlot != -1)
		{
			highScores.Insert(highSlot, (int)score);
		}
		else
		{
			highScores.Add((int)score);
		}
		
		//Save high score list
		for(int i = 0; i < highScores.Count; i++)
		{
			PlayerPrefs.SetInt("HighScore" + i.ToString(), highScores[i]);
		}
		
		PlayerPrefs.SetInt("ScoreNumber", highScores.Count);
		
		PlayerPrefs.Save();
	}
	
	void LoadHighScore()
	{
		highScores.Clear();
		for(int i = 0; i < PlayerPrefs.GetInt("ScoreNumber"); i++)
		{
			highScores.Add(PlayerPrefs.GetInt("HighScore" + i.ToString()));
		}
		
		highScore = PlayerPrefs.GetInt("HighScore0");
	}
}
