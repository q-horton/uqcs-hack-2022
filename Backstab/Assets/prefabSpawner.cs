using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawner : MonoBehaviour
{
    private float nextSpawnTime;
    public static int EnemyCount = 0;
    public int difficulty = 5;

    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    public float spawnDelay = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
