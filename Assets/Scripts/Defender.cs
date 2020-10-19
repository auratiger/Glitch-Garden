using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject projectileSpawner;
    
    public void Fire()
    {
        Instantiate(projectile, projectileSpawner.transform.position, transform.rotation);    return;
    }
}
