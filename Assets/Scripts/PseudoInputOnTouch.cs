using UnityEngine;
using System.Collections;

public class PseudoInputOnTouch : MonoBehaviour
{
	void OnTouchDown()
	{
		if(GameManager.Instance.gameover)
		{
			PseudoInput.Instance.jumpPressed = false;
			GameManager.Instance.SendMessage("RestartGame");
		}
		else
		{
			PseudoInput.Instance.jumpPressed = true;
		}
	}
	void OnTouchUp()
	{
		PseudoInput.Instance.jumpPressed = false;
	}
}