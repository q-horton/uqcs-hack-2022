using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawner : MonoBehaviour
{
    private float nextSpawnTime;
    public static int EnemyCount = 0;
    public int difficulty = 20;

    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    public float spawnDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn()) {
            Spawn();
        }
    }
    float randomX = 0;
    float randomY = 0;
    

    private void Spawn()
    {
        randomX = Random.Range(-100f,100f);
        randomY = Random.Range(-150f,150f);
        Vector3 randomPlace = new Vector3(randomX, 1.5f, randomY);
        nextSpawnTime = Time.time + spawnDelay;
        if (EnemyCount < difficulty) {
            Instantiate(EnemyPrefab, randomPlace, transform.rotation); 
            EnemyCount ++;
        }
    }

    private bool ShouldSpawn() {
        return Time.time >= nextSpawnTime;
    }
}
