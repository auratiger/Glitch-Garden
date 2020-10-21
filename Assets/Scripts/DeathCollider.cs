using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Dead");
        // FindObjectOfType<LevelLoader>().LoadLoseScreen();
        Destroy(other.gameObject);
    }
}
