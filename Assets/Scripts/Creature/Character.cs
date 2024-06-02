using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float moveSpeed = 3f;
    Vector3 moveVector ;
    public Image hpBarImage;
    public Image expBarImage;
    public float Health = 100;
    public static int Exp = 0;
    public static int MaxExp = Level * 5;
    public static int Level = 1;
    private float expPercent;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        HpBar();
        ExpBar();
        MoveTransform() ;
        if (Health < 1)
        {
            CharaterDead();
        }
        Levelup();
    }

    void MoveTransform()
    {
        moveVector = Vector3.zero ;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.up ;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector += -1 * transform.up ;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right ;   
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector += -1 * transform.right ;
        }

        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime  ;
        
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy")) 
        {
                StartCoroutine(TakeDamage());
        }
        if (other.CompareTag("ExpObj")) 
        {
                Exp += 1;
        }
    }

    IEnumerator TakeDamage()
    {
        while (true)
        {
            Health -= 10;
            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StopAllCoroutines();
        }
    }

    void CharaterDead()
    {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
    }

    private void HpBar() {
        float hpPercent = Health / 100f;
        hpBarImage.fillAmount = hpPercent;
    }

    private void ExpBar() {
        if (Level >= 8)
        {
            expPercent = 1;
        }
        else
        {
            expPercent = (float)Exp / (float)(Level*5);
        }
        expBarImage.fillAmount = expPercent;
    }

    private void Levelup()
    {
        if(expPercent == 1 && Level < 8)
        {
            Level ++;
            Exp = 0;
        }
    }
}
