using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour {

	// Use this for initialization
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
