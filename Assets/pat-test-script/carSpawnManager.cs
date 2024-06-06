using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawnManager : MonoBehaviour
{
    public GameObject car;
    public Transform spawnPoint;
    private float spawnInterval;
    [SerializeField] private Vector2 spawnIntervalVector2;
    private bool shouldSpawn = true;
    private bool haveSpawn = false;

    private float timer;

    public void Start()
    {
        spawnInterval = Random.Range(spawnIntervalVector2.x, spawnIntervalVector2.y);
     
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            spawnInterval = Random.Range(spawnIntervalVector2.x, spawnIntervalVector2.y);
            Instantiate(car, spawnPoint.position, Quaternion.identity);
            timer = 0;
        }
    }
}
