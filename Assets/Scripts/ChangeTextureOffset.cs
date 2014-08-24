using UnityEngine;
using System.Collections;

public class ChangeTextureOffset : MonoBehaviour
{
	public float speed = 1.0f;

	// Update is called once per frame
	void Update ()
	{
		renderer.material.mainTextureOffset += Vector2.right*speed*Time.deltaTime;
	}
}
