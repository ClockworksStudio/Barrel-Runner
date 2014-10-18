using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowGameover : MonoBehaviour
{
	private string label;
	private Text gameoverText;

	void Start()
	{
		gameoverText = GetComponent<Text>();
		label = gameoverText.text;
	}
	void Update()
	{
		if(GameManager.Instance.gameover)
		{
			gameoverText.text = label;
		}
		else
		{
			gameoverText.text = "";
		}
	}
}
