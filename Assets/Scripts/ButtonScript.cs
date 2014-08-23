using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	public enum ButtonType{Play, Highscores, Credits, Menu, Quit}
	public ButtonType buttonType;

	public string gameLevel;
	public string highscoresLevel;
	public string creditsLevel;
	public string menuLevel;

	void Touched()
	{
		if(buttonType == ButtonType.Play)
		{
			Application.LoadLevel(gameLevel);
		}
		else if(buttonType == ButtonType.Highscores)
		{
			Application.LoadLevel(highscoresLevel);
		}
		else if(buttonType == ButtonType.Credits)
		{
			Application.LoadLevel(creditsLevel);
		}
		else if(buttonType == ButtonType.Menu)
		{
			Application.LoadLevel(menuLevel);
		}
		else if(buttonType == ButtonType.Quit)
		{
			Application.Quit();
		}
		else
		{
			Debug.LogError("Button type not defined on object '"+gameObject.name+"'", gameObject);
		}
	}
}
