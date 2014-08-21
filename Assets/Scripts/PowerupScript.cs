using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour
{
	public enum powerupList 
	{
		NoDamage, SpeedBooster, JumpBooster
	}
	public powerupList powerupType;
	public float speedBoost = 1.0f;
	public float jumpBoost = 1.0f;
	public int duration = 1;
	public int coolDown = 2;

	public bool activated = false;
	public int durationTimer = 0;
	public int coolDownTimer = 0;
	public bool running = false;
	public float timer = 0;

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
		if(durationTimer == duration && running)
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
}
