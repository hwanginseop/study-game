using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] int spawnAmount = 1;
    [SerializeField] int weaponLevel = 1;
    [SerializeField] GameObject AxeObject;

    private void Start()
    {
        StartCoroutine(SpawnByTime());
    }

    IEnumerator SpawnByTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            for (int i = 0; i < weaponLevel; i++)
            {
                SpawnObject();
            }
        }
    }

    GameObject SpawnObject()
    {
        GameObject Axe = Instantiate(AxeObject, GetSpawnPos(), Quaternion.identity);
        return Axe;
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

