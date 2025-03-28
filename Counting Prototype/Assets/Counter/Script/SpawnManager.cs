using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    public float delayMin = 0.75f;
    public float delayMax = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnFish()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(xMin, xMax), 20, Random.Range(zMin, zMax));
            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(prefab, spawnPos, prefab.transform.rotation);
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
        }
    }
}
