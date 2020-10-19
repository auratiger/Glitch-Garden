using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Range(0f, 10f)][SerializeField] private float speed = 1f;
    [SerializeField] private int damage = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var enemy = other.GetComponent<Enemy>();

        if (enemy && health)
        {
            health.DeadDamage(damage);
            Destroy(gameObject);
        }
    }
}
