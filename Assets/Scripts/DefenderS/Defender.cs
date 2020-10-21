using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;

    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarsDisplay>().AddStars(amount);
    }

    public void OnMouseDown()
    {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController.IsDeleteCursor())
        {
            Destroy(gameObject);
            levelController.SetDeleteCursor(false);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
