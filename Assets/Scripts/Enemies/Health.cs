using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private GameObject deathVFX;

    public void DeadDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) return;

        GameObject deathVFXobject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXobject, 1f);
    }
}
