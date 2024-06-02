using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    float moveSpeed = 2f;
    Vector3 moveVector;
    public GameObject ExpObjectPrefab;

    void Start()
    {
        
    }
    
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveVector = player.transform.position - transform.position;
        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Weapon")) 
        {
                EnemyDead() ;
                LeaveExp() ;
                EnemyManager.DeadCount ++ ;
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }

    GameObject LeaveExp() 
    {
        return Instantiate(ExpObjectPrefab ,transform.position, Quaternion.identity);
    }
}
