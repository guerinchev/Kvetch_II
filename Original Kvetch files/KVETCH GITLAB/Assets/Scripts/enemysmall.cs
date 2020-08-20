using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysmall : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 2;
    public SpriteRenderer sr;
    private float flipTime;

    // Start is called before the first frame update
    void Start()
    {
        flipTime = 0.0f;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (flipTime > 0)
        {
            flipTime -= Time.deltaTime;
        }
        rb.velocity = new Vector2(speed, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Flipping")
        {
            if (flipTime <= 0)
            {
                flipTime = 0.1f;
                if (sr.flipX == false)
                {
                    sr.flipX = true;
                    speed = -2;
                }
                else
                {
                    sr.flipX = false;
                    speed = 2;
                }
            }
            

        }
    }
}

