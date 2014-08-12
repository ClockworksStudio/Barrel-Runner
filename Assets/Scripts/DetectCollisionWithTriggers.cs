using UnityEngine;
using System.Collections;

public class DetectCollisionWithTriggers : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Crayon Trigger: " + other.name);
	}
}
