using UnityEngine;

public class Sanctuary : MonoBehaviour
{
    float Timescale = 0;
    int weaponLevel = 1; 
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        transform.position = player.transform.position;
        Timescale += 1f * Time.deltaTime;
        if (Timescale > 1.5f *  weaponLevel)
        {
            Destroy(gameObject);
            Timescale = 0;
        }
    }

    public void LevelUp()
    {
        weaponLevel++;
    }
}