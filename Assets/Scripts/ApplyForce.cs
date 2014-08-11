using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour
{
	public float moveSpeed = 10.0f;

	// Update is called once per frame
	void Update ()
	{
		transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
	}
}
