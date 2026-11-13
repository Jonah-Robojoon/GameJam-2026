using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject EnemyPrefab;

    public List<Transform> Betweenpoints = new List<Transform>();
    public Transform xpos;
    
    public float spawnInterval = 6f; // Time interval between spawns

    private void SpawnEnemy()
    {
        float Ypos = Random.Range(Betweenpoints[0].position.y, Betweenpoints[1].position.y);

        Vector3 spawnPosition = new Vector3(xpos.position.x, Ypos, 0f);

        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
    }
    private void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0f)
        {
            SpawnEnemy();
            spawnInterval = 1.5f; // Reset the spawn interval
        }
    }



}
