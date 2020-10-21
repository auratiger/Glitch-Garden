using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Range(0f, 5f)] protected float walkSpeed = 1f;

    protected GameObject _currentTarget;
    protected Animator _animator;
    
    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<LevelController>().EnemySpawned();
        _animator = GetComponent<Animator>();
    }

    protected void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.EnemyKilled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateAnimationState();
    }

    protected void Move()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * walkSpeed));
    }

    protected void UpdateAnimationState()
    {
        if (!_currentTarget)
        {
            _animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        _animator.SetBool("isAttacking", true);
        _currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if(!_currentTarget) return;

        Health health = _currentTarget.GetComponent<Health>();

        if (health)
        {
            health.DeadDamage(damage);
        }
    }
}
