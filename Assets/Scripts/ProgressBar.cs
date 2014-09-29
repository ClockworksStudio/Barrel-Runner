using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressBar : MonoBehaviour
{

	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	public TextMesh textMesh;
	public string barName;
	public string prefix;
	public int decimalPlaces;
	public int[] valueRange;
	public bool onlyRunInGame = true;
	public List<string> levelList = new List<string>();

	private float progress = 0.0f;
	private bool activated = false;
	//private Vector3 targetPos;
	private float barDisplayValue;

	void Start()
	{
		progress = 0.0f;
	}

	void OnGUI()
	{
		barDisplayValue = Mathf.Lerp(valueRange[0],valueRange[1],progress);
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x * Mathf.Clamp01(progress), size.y), progressBarFull);
		textMesh.text = barName + ": " + barDisplayValue.ToString("F" + decimalPlaces)+prefix;
	} 
	void Update()
	{
		if(onlyRunInGame)
		{
			foreach(string str in levelList)
			{
				if(Application.loadedLevelName == str)
				{
					if(!GameManager.Instance.gameover)
					{
						if(activated)
						{
							if(progress >= 0)
							{
								progress = Time.time * -0.10f;
							}
							else
							{
								activated = false;
							}
						}
						else
						{
							if(progress <= 1)
							{
								progress = Time.time * 0.05f;
							}
						}
					}
					break;
				}
			}
		}
		else
		{
			if(progress <= 1)
			{
				progress = Time.time * 0.05f;
			}
		}
	}
	public float GetBarPercent()
	{
		return progress;
	}
	public bool SetActive(bool active)
	{
		return activated = active;
	}
}
