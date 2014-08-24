using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour
{
	public float moveSpeed = 10.0f;
	public float rotateSpeed = 10.0f;
	public bool applyRotation = false;

	// Update is called once per frame
	void Update ()
	{
		transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
		if(applyRotation)
		{
			transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
		}
	}
}
