using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
	public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFruits());
        minDelay = .01f + (Stats.fruitSpawnRate * 0.5f);
        maxDelay = .05f + (Stats.fruitSpawnRate * 0.5f);
    }

	IEnumerator SpawnFruits ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 10f);
		}
	}
	
}
