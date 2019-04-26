using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public float spawnDelay = 0f;
    float nextTimeToSpawn = 0f;

    public GameObject car;
	public Transform[] spawnPoints;

    void Start()
    {
        spawnDelay = 1 / Stats.carSpawnRate;
    }

    void Update ()
	{
		if (nextTimeToSpawn <= Time.time)
		{
			SpawnCar();
			nextTimeToSpawn = Time.time + spawnDelay;
		}
	}

	void SpawnCar ()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[randomIndex];

		Instantiate(car, spawnPoint.position, spawnPoint.rotation);
	}

}
