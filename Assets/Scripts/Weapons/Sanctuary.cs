using UnityEngine;

public class Sanctuary : MonoBehaviour
{
    float Timescale = 0;
    public static int SanctuaryLevel = 1; 
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        transform.position = player.transform.position;
        Timescale += 1f * Time.deltaTime;
        if (Timescale > 1.5f *  SanctuaryLevel)
        {
            Destroy(gameObject);
            Timescale = 0;
        }
    }
}