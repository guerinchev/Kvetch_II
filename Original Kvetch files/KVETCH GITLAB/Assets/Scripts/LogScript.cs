using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.tag == "break")
        {
            Debug.Log("Enemy hit");
        }
        else
        {
            Debug.Log("I am broken");
        }
    }
}
