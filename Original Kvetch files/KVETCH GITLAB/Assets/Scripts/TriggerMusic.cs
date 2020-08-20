using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!triggered)
            {
                triggered = true;
            }
        }
    }

    internal bool IsTriggered()
    {
        return triggered;
    }
}
