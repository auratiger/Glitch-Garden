using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Robot : Enemy
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("a");
    }

    private void FixedUpdate()
    {
        TriggerCollapse();
    }

    private void TriggerCollapse()
    {
        if (Math.Abs(transform.position.x - 5) < 0.1)
        {
            _animator.SetTrigger("CollapseTrigger");
        }
    }

    private void TriggerExpand()
    {
        _animator.SetTrigger("ExpandTrigger");
    }
}
