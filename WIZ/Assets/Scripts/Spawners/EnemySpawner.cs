using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public bool continuous;
    public float spawnTimeInterval;
    public int spawnLimit;
    public float spawningRadius;

    public GameObject enemyPrefab;

    float timer;
    int enemiesSpawned;

    // Start is called before the first frame update
    void Start()
    {
        if (!continuous)
        {
            SpawnSingleEnemy(enemyPrefab, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (continuous && timer > spawnTimeInterval && enemiesSpawned < spawnLimit)
        {
            SpawnSingleEnemy(enemyPrefab, transform.position);

            enemiesSpawned++;
            if (timer > spawnTimeInterval) timer = 0f;
        }
    }

    public void SpawnSingleEnemy(GameObject enemyToSpawn, Vector3 spawnPosition)
    {
        Instantiate(enemyToSpawn, spawnPosition, transform.rotation);
        Debug.Log("Spawning single enemy.");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawningRadius);
    }
}
