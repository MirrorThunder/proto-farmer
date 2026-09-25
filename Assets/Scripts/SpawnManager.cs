using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
	public GameObject[] animalPrefabs;
	public InputAction spawnAction;
	private float spawnRangeX = 20;
	private float spawnPosZ = 20;
	private float startDelay = 2;
	private float spawnInterval = 1.5f;

	void Start()
	{
		spawnAction.Enable();
		InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
	}

	void Update()
	{
		if (spawnAction.WasPressedThisFrame())
		{
    		SpawnRandomAnimal();
		}
	}

	void SpawnRandomAnimal()
	{
		int animalIndex = Random.Range(0, animalPrefabs.Length);
		Vector3 spawnPos = new Vector3(
		Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
		Instantiate(animalPrefabs[animalIndex],
		spawnPos,
		animalPrefabs[animalIndex].transform.rotation);
	}
}
