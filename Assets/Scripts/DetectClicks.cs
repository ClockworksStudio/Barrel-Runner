using UnityEngine;
using System.Collections;

public class DetectClicks : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayhit;
			if(Physics.Raycast(ray, out rayhit))
			{
				Debug.Log("You clicked on: "+rayhit.collider.name, rayhit.collider.gameObject);
			}
		}
	}
}
