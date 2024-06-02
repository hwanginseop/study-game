using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanctuarySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 10f;
    [SerializeField] int spawnAmount = 1;
    [SerializeField] int weaponLevel = 1;
    [SerializeField] GameObject SanctuaryObject;

    private void Start()
    {
        StartCoroutine(SpawnByTime());
    }

    IEnumerator SpawnByTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnObject();
        }
    }

    GameObject SpawnObject()
    {
        GameObject Sanctuary = Instantiate(SanctuaryObject, GetSpawnPos(), Quaternion.identity);
        return Sanctuary;
    }

    Vector3 GetSpawnPos()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 spawnPosition = player.transform.position;
        return spawnPosition;
    }

    void Update()
    {
        
    }
}

