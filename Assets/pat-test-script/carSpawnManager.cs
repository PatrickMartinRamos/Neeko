using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    public Transform spawnTransform;
    public List<GameObject> cars; // List of cars to spawn at this point
    public Vector2 spawnIntervalRange; // Interval range for this spawn point
    public Transform targetPoint; // Target point for this spawn point
    public float minimumSpawnDelay = 1.5f; // Minimum delay between spawns

    [HideInInspector] public float timer; // Timer for this spawn point
    [HideInInspector] public float spawnInterval; // Current spawn interval
}

public class carSpawnManager : MonoBehaviour
{
    private audioManager _audioManagerInstance;
    public List<SpawnPoint> spawnPoints; // List of spawn points

    private void Awake()
    {
        _audioManagerInstance = audioManager.instance;
    }

    private void Start()
    {
        playCarAmbience();
        foreach (var spawnPoint in spawnPoints)
        {
            spawnPoint.spawnInterval = Random.Range(spawnPoint.spawnIntervalRange.x, spawnPoint.spawnIntervalRange.y);
            spawnPoint.timer = 0;
        }
    }

    private void Update()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            spawnPoint.timer += Time.deltaTime;

            if (spawnPoint.timer >= spawnPoint.spawnInterval && spawnPoint.timer >= spawnPoint.minimumSpawnDelay)
            {
                spawnPoint.spawnInterval = Random.Range(spawnPoint.spawnIntervalRange.x, spawnPoint.spawnIntervalRange.y);
                SpawnCar(spawnPoint);
                spawnPoint.timer = 0;
            }
        }
    }

    private void SpawnCar(SpawnPoint spawnPoint)
    {
        if (spawnPoint.cars.Count > 0)
        {
            int carIndex = Random.Range(0, spawnPoint.cars.Count);
            GameObject carInstance = Instantiate(spawnPoint.cars[carIndex], spawnPoint.spawnTransform.position, Quaternion.identity);

            // Set the target point for the car
            carLogic carLogicScript = carInstance.GetComponent<carLogic>();
            if (carLogicScript != null)
            {
                carLogicScript.SetTarget(spawnPoint.targetPoint);
            }
        }
    }
    void playCarAmbience()
    {
        _audioManagerInstance.Play("CarAmbience");
    }
}
