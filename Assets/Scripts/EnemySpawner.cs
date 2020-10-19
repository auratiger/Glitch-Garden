using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool _spawn = true;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Enemy enemyPrefab;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (_spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
