using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject winLabel;
    [SerializeField] private float waitToLoad = 4f;
    
    private int _numberOfEnemies = 0;
    private bool _levelTimerFinished = false;

    private bool _deleteCursorSet = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void EnemySpawned()
    {
        _numberOfEnemies++;
    }

    public void EnemyKilled()
    {
        _numberOfEnemies--;
        if (_numberOfEnemies <= 0 && _levelTimerFinished)
        {
            Debug.Log("End Level now");
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void LevelTimerFinished()
    {
        _levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    public bool IsDeleteCursor()
    {
        return _deleteCursorSet;
    }

    public void SetDeleteCursor(bool cursor)
    {
        _deleteCursorSet = cursor;
    }
}
