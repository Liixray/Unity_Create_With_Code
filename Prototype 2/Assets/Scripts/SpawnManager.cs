using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 2.0f;

    private float startDelayLeft = 1.5f;
    private float startDelayRight = 2.5f;
    private float spawnIntervalSide = 3.0f;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelayLeft, spawnIntervalSide);
        InvokeRepeating("SpawnRightAnimal", startDelayRight, spawnIntervalSide);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        //Randomlu generate animal index and spawn positon
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX/2, spawnRangeX / 2), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos
            , animalPrefabs[animalIndex].transform.rotation);
    }


    void SpawnLeftAnimal()
    {
        Vector3 rotation = new Vector3(0, 90, 0);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos
            , Quaternion.Euler(rotation));
    }
    void SpawnRightAnimal()
    {
        Vector3 rotation = new Vector3(0, -90, 0);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos
            , Quaternion.Euler(rotation));
    }
}
