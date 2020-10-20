using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool _spawn = true;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Enemy[] enemyPrefabArray;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (_spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }
    }

    public void StopSpawning()
    {
        _spawn = false;
    }

    private void SpawnEnemy()
    {
        var enemyIndex = Random.Range(0, enemyPrefabArray.Length);
        Spawn(enemyPrefabArray[enemyIndex]);
    }

    private void Spawn(Enemy enemy)
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, transform.rotation) as Enemy;

        newEnemy.transform.parent = transform;
    }
}
