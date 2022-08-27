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

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        if (EnemyCount < difficulty) {
            Instantiate(EnemyPrefab, transform.position, transform.rotation); 
            EnemyCount ++;
        }
    }

    private bool ShouldSpawn() {
        return Time.time >= nextSpawnTime;
    }
}
