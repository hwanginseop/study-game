using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    Transform target;
    Vector3 moveVector;

    Transform FindShortestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearestEnemy = null;
        float shortestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }

    void Start()
    {   
        target = FindShortestTarget();
        if (target == null)
        {
            // 목표가 없을 경우 Bullet을 제거하지 않고, 앞으로 나아가도록 설정
            moveVector = transform.up; // 기본 이동 방향
        }
        else
        {
            moveVector = (target.position - transform.position).normalized;
        }
    }

    void Update()
    {
        // target이 null일 경우를 처리
        if (target != null)
        {
            moveVector = (target.position - transform.position).normalized;
        }

        transform.position += moveVector * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
