using UnityEngine;
using System.Collections;

public class DetectClicksOrTouches : MonoBehaviour
{
	public LayerMask touchableLayers = -1;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayhit;
			if(Physics.Raycast(ray, out rayhit, Mathf.Infinity, touchableLayers))
			{
				//Debug.Log("You clicked on: "+rayhit.collider.name, rayhit.collider.gameObject);
				rayhit.collider.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
			}
		}
		if(Input.touchCount > 0)
		{
			foreach(Touch touch in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay((Vector3)touch.position);
				
				RaycastHit hit;
				
				if(Physics.Raycast(ray, out hit, Mathf.Infinity, touchableLayers))
				{
					//Debug.Log("You touched: " + hit.collider.name, hit.collider.gameObject);
					hit.collider.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
