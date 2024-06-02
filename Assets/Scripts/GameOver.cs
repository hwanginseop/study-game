using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Character CH;
    AxeSpawner AS;
    BulletSpawner BS;
    Sanctuary ST;
    GameObject EN;

    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        CH = FindObjectOfType<Character>();
        AS = FindObjectOfType<AxeSpawner>();
        BS = FindObjectOfType<BulletSpawner>();
        ST = FindObjectOfType<Sanctuary>();
        EN = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
        if (Input.anyKeyDown)
        {
            Restart();
        }
    }

    public void Restart()
    {
        GameOverPanel.SetActive(false);
        ClearComponent();
        Time.timeScale = 1f;
        CH.transform.position = new Vector3(0,0,0);
        Destroy(EN);
    }

    public void ClearComponent()
    {
        CH.Health = 100;
        Character.Exp=0;
        Character.Level=1;
        AxeSpawner.AxeLevel=1;
        BulletSpawner.BulletLevel=1;
        Sanctuary.SanctuaryLevel=1;
    }
}
