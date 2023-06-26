using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private void Start()
    {
        StartCoroutine(SpawnerDelay());
    }
    public void SpawnEnemy()
    {
        
        Vector3 randomPos = new Vector3(Random.Range(-27, 27), transform.position.y, transform.position.z);
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
    IEnumerator SpawnerDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            SpawnEnemy();
        }
    }
}
