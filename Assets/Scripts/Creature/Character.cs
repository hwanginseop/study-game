using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float moveSpeed = 3f;
    Vector3 moveVector;
    public Image hpBarImage;
    public Image expBarImage;
    public int Health = 100;
    public static int Exp = 0;
    public static int MaxExp = Level * 5;
    public static int Level = 1;
    private float expPercent;
    private WeaponSelection weaponSelection;
    private GameOver GameOver;

    void Start()
    {
        weaponSelection = FindObjectOfType<WeaponSelection>();
        GameOver = FindObjectOfType<GameOver>(); 
    }

    void Update()
    {
        HpBar();
        ExpBar();
        MoveTransform();
        if (Health < 1)
        {
            CharacterDead();
        }
        LevelUp();
    }

    void MoveTransform()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector += -transform.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector += -transform.right;
        }

        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
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

    void CharacterDead()
    {
        GameOver.ShowGameOver();
    }

    private void HpBar()
    {
        float hpPercent = Health / 100f;
        hpBarImage.fillAmount = hpPercent;
    }

    private void ExpBar()
    {
        if (Level >= 8)
        {
            expPercent = 1;
        }
        else
        {
            expPercent = (float)Exp / (float)(Level * 5);
        }
        expBarImage.fillAmount = expPercent;
    }

    private void LevelUp()
    {
        if (expPercent == 1 && Level < 8)
        {
            Level++;
            Exp = 0;
            MaxExp = Level * 5;
            weaponSelection.ShowUpgradePanel();
        }
    }

    public void SetSelectedWeapon(WeaponSelection.Weapon selectedWeapon)
    {
        UpgradeWeapon(selectedWeapon);
    }

    private void UpgradeWeapon(WeaponSelection.Weapon selectedWeapon)
    {
        if (selectedWeapon.weaponName == "Sanctuary")
        {
            Sanctuary.SanctuaryLevel++;
        }
        else if (selectedWeapon.weaponName == "BulletSpawner")
        {
            BulletSpawner.BulletLevel++;
        }
        else if (selectedWeapon.weaponName == "AxeSpawner")
        {
            AxeSpawner.AxeLevel++;
        }
        else if (selectedWeapon.weaponName == "MaxHealth")
        {
            Health = 100;
        }
    }
}
