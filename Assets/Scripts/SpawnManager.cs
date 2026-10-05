using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public InputAction spawnAction;

    private float spawnRangeX = 20f;
    private float spawnPosZ = 20f;

    private float startDelay = 2f;

    private float spawnInterval = 1.5f;
    private float minimumSpawnInterval = 0.5f;

    private float difficultyTimer = 0f;
    private float difficultyIncreaseTime = 10f;

    private float spawnTimer = 0f;
    private float gameTimer = 0f;

    void Start()
    {
        spawnAction.Enable();
    }

    void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer >= startDelay)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnRandomAnimal();
                spawnTimer = 0f;
            }
        }

        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= difficultyIncreaseTime)
        {
            IncreaseDifficulty();
            difficultyTimer = 0f;
        }

        if (spawnAction.WasPressedThisFrame())
        {
            SpawnRandomAnimal();
        }
    }

    void IncreaseDifficulty()
    {
        spawnInterval -= 0.3f;

        if (spawnInterval < minimumSpawnInterval)
        {
            spawnInterval = minimumSpawnInterval;
        }

        Debug.Log("Dificultad aumentada. Spawn cada: " + spawnInterval + " segundos");
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            0,
            spawnPosZ
        );

        Instantiate(
            animalPrefabs[animalIndex],
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation
        );
    }
}