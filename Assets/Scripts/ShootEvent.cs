using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEvent : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject projectileSpawner;

    private Animator _animator;
    private EnemySpawner _myLaneSpawner;
    
    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsEnemyInLane())
        {
               _animator.SetBool("isAttacking", true); 
        }
        else
        {
            _animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        
        foreach (EnemySpawner spawner in spawners)
        {
            bool IsCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                _myLaneSpawner = spawner;
                
            }
        }
    }

    private bool IsEnemyInLane()
    {
        // return false if no children are spawned in the lane
        return _myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(projectile, projectileSpawner.transform.position, transform.rotation);    return;
    }
}
