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

    private GameObject _projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";
    
    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        _projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!_projectileParent)
        {
            _projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
        var newProjectile = 
            Instantiate(projectile, projectileSpawner.transform.position, transform.rotation);

        newProjectile.transform.parent = _projectileParent.transform;
    }
}
