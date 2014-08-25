using UnityEngine;
using System.Collections;

public class TakeScreenshots : MonoBehaviour
{
	public string screenshotKey = "p";

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(screenshotKey))
		{
			Application.CaptureScreenshot("Screenshot" + System.DateTime.Now.ToString("yyMMdd H.mm.ss") + ".png",3);
		}
	}
}
