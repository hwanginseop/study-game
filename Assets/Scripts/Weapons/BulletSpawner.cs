using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] int spawnAmount = 1;
    public static int BulletLevel = 1;
    [SerializeField] GameObject bulletObject;

    private void Start()
    {
        StartCoroutine(SpawnByTime());
    }

    IEnumerator SpawnByTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            for (int i = 0; i < spawnAmount * BulletLevel; i++)
            {
                SpawnObject();
            }
        }
    }

    GameObject SpawnObject()
    {
        GameObject bullet = Instantiate(bulletObject, GetSpawnPos(), Quaternion.identity);
        // Bullet이 생성된 후 초기 위치에서 약간 이동
        bullet.transform.position += bullet.transform.up * 0.5f; 
        return bullet;
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

