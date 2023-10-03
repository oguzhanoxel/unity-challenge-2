using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 16;
    private float spawnRangeTopZ = 20;
    private float spawnRangeBottomZ = 0;
    private float spawnPosZ = 20;
    private float spawnPosLeftX = -20;

    private float startDelay = 2;
    private float spawnInternal = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalUpToBack", startDelay, spawnInternal);
        InvokeRepeating("SpawnRandomAnimalLeftToRight", startDelay, spawnInternal);
        InvokeRepeating("SpawnRandomAnimalRightToLeft", startDelay, spawnInternal);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimalUpToBack()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosTopBottom = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        animalPrefabs[animalIndex].transform.rotation = Quaternion.LookRotation(Vector3.back);

        Instantiate(animalPrefabs[animalIndex], spawnPosTopBottom, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeftToRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosLeftRight = new Vector3(spawnPosLeftX, 0, Random.Range(spawnRangeBottomZ, spawnRangeTopZ));

        animalPrefabs[animalIndex].transform.rotation = Quaternion.LookRotation(Vector3.right);

        Instantiate(animalPrefabs[animalIndex], spawnPosLeftRight, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalRightToLeft()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosLeftRight = new Vector3(-spawnPosLeftX, 0, Random.Range(spawnRangeBottomZ, spawnRangeTopZ));

        animalPrefabs[animalIndex].transform.rotation = Quaternion.LookRotation(Vector3.left);

        Instantiate(animalPrefabs[animalIndex], spawnPosLeftRight, animalPrefabs[animalIndex].transform.rotation);
    }
}
