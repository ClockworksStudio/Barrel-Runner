using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBarrel : MonoBehaviour {

	public List<GameObject> barrelList = new List<GameObject>();
	public float minHorizontal = -10.0f;
	public float maxHorizontal = 10.0f;
	public float minVertical = -10.0f;
	public float maxVertical = 10.0f;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 1.0f;
	
	// Use this for initialization
	void Start ()
	{
		Invoke ("Spawn", Random.Range(minSpawnTime, maxSpawnTime));
	}
	
	void Spawn()
	{
		if(!GameManager.Instance.gameover)
		{
			int barrelIndex = UnityEngine.Random.Range(0,barrelList.Count);
			Instantiate(barrelList[barrelIndex], transform.position + new Vector3(Random.Range(minHorizontal,maxHorizontal),Random.Range(minVertical,maxVertical)), Quaternion.identity);
			Invoke ("Spawn", Random.Range(minSpawnTime, maxSpawnTime));
		}
	}
}
