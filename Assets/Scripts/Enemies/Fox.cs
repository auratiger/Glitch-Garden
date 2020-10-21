using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Enemy
{

    private bool _hasJumped = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            if (!_hasJumped)
            {
                GetComponent<Animator>().SetTrigger("jumpTrigger");
                _hasJumped = true;
            }
            else
            {
                GetComponent<Enemy>().Attack(otherObject);
            }
        }
    }
}
