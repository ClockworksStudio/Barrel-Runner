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
			return _instance;
		}
	}
	public List<string> levelList = new List<string>();
	public int menuLevelNumber;
	public int creditsLevelNumber;
	public int scoreMultiplier = 1;
	public float musicVolume = 0.5f;
	public float soundVolume = 1.0f;

	public AudioSource creditsMusic;
	public AudioSource gameMusic;

	private bool musicToggle = true;
	private string musicToggleText = "Disable Music";
	private List<int> highScores = new List<int>();
	private static GameManager _instance;
	public static float highScore = 0.0f;

	[HideInInspector]
	public float score = 0;
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
		gameMusic.Play();
		highScores.Capacity = 5;
		LoadHighScore();
	}
	void OnLevelWasLoaded(int level)
	{
		if (level == creditsLevelNumber)
		{
			gameMusic.Stop();
			creditsMusic.Play();
		}
		if (level == menuLevelNumber)
		{
			if(!gameMusic.isPlaying)
			{
				creditsMusic.Stop();
				gameMusic.Play();
			}
		}
	}
	// Update is called once per frame
	void Update()
	{
		if(Input.anyKeyDown && gameover)
		{
			RestartGame();
		}
		foreach(string str in levelList)
		{
			if(Application.loadedLevelName == str)
			{
				if(!gameover)
				{
					score += Time.deltaTime*scoreMultiplier;
				}
				break;
			}
		}
	}
	void RestartGame()
	{
		SaveHighScore();
		score = 0;
		gameover = false;
		Application.LoadLevel(menuLevelNumber);
	}
	void OnGUI() {
		if(Application.loadedLevelName == "Menu")
		{
			if(musicToggle)
			{
				gameMusic.volume = musicVolume;
				creditsMusic.volume = musicVolume;
				musicToggleText = "Disable Music";
			}
			else
			{
				gameMusic.volume = 0;
				creditsMusic.volume = 0;
				musicToggleText = "Enable Music";
			}
			musicToggle = GUI.Toggle(new Rect(500, 160, 300, 30), musicToggle, musicToggleText);

			GUI.Label(new Rect(590, 185, 300, 30),"Music Volume: "+(int)(musicVolume*100)+"%");
			musicVolume = GUI.HorizontalSlider(new Rect(500, 205, 300, 30), musicVolume, 0.0f, 1.0f);
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
