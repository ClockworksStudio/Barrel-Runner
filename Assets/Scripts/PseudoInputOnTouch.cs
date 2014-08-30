using UnityEngine;
using System.Collections;

public class PseudoInputOnTouch : MonoBehaviour
{
	//public enum PseudoInputDirecton {Left, Right}
	//public PseudoInputDirecton direction;
	
	void OnTouchDown()
	{
		if(GameManager.Instance.gameover)
		{
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