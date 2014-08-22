using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour
{
	public enum powerupList {NoDamage, SpeedBooster, JumpBooster}
	public powerupList powerupType;
	public float speedBoost = 1.0f;
	public float jumpBoost = 1.0f;
	public int duration = 1;
	public int coolDown = 2;

	private bool activated = false;
	private int durationTimer = 0;
	private int coolDownTimer = 0;
	private bool running = false;
	private float timer = 0;
	private bool deactivated = true;

	void Start()
	{
		durationTimer = duration;
		coolDownTimer = coolDown;
	}

	// Update is called once per frame
	void Update ()
	{
		if(activated && !running)
		{
			timer = 0;
			activated = false;
			Activate();
			durationTimer = 0;
			coolDownTimer = 0;
			running = true;
		}
		if(running)
		{
			timer += Time.deltaTime;
		}
		if(durationTimer == duration && running && !deactivated)
		{
			Deactivate();
		}
		else if(durationTimer < duration && running)
		{
			durationTimer = (int)timer;
		}

		if(coolDownTimer == coolDown && running)
		{
			Debug.Log("Resetting powerup");
			running = false;
		}
		else if(coolDownTimer < coolDown && running)
		{
			coolDownTimer = (int)timer;
		}
	}
	void Activate()
	{
		deactivated = false;
		Debug.Log("Activated");
		if(powerupType == powerupList.NoDamage)
		{
			PlayerManager.noDamage = true;
		}
		else if(powerupType == powerupList.SpeedBooster)
		{
		}
		else if(powerupType == powerupList.JumpBooster)
		{
		}
		else
		{
			Debug.LogError("Powerup type not defined on object '"+gameObject.name+"'", gameObject);
		}
	}
	void Deactivate()
	{
		deactivated = true;
		Debug.Log("Deactivated");
		if(powerupType == powerupList.NoDamage)
		{
			PlayerManager.noDamage = false;
		}
		else if(powerupType == powerupList.SpeedBooster)
		{
		}
		else if(powerupType == powerupList.JumpBooster)
		{
		}
		else
		{
			Debug.LogError("Powerup type not defined on object '"+gameObject.name+"'", gameObject);
		}
	}
	void Touched()
	{
		if (!running && coolDownTimer == coolDown)
		{
			Debug.Log("Touch detected on: "+gameObject.name, gameObject);
			activated = true;
		}
	}
}
