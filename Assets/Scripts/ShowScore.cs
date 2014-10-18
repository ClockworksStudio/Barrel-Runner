using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScore : MonoBehaviour
{
	private string label;
	private Text uiText;
	
	// Use this for initialization
	void Start ()
	{
		uiText = GetComponent<Text>();
		label = uiText.text;
	}
	
	void Update()
	{
		uiText.text = label + (int)GameManager.Instance.score;
	}
}
