using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigenemy : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public SpriteRenderer sr;
    private float flipTime; //avoiding script renderer from double flipping

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (rb.gameObject.name.StartsWith("enemydash", System.StringComparison.Ordinal))
        {
            speed = 12;
        }
        else if (rb.gameObject.name.StartsWith("train", System.StringComparison.Ordinal))
        {
            speed = 20;
        }
        else if (rb.gameObject.name.StartsWith("camera", System.StringComparison.Ordinal))
        {
            speed = 4;
        }
        else if (rb.gameObject.name.StartsWith("flower", System.StringComparison.Ordinal))
        {
            speed = 6;
        }
        else if (rb.gameObject.name.StartsWith("spider", System.StringComparison.Ordinal))
        {
            speed = 8;
        }
        else if (rb.gameObject.name.StartsWith("movesp", System.StringComparison.Ordinal))
        {
            speed =3;
        }
        else if (rb.gameObject.name.StartsWith("smallV2", System.StringComparison.Ordinal))
        {
            speed = 15;
        }
        else if (rb.gameObject.name.StartsWith("V3", System.StringComparison.Ordinal))
        {
            speed = -20;
        }
        else if (rb.gameObject.name.StartsWith("small", System.StringComparison.Ordinal))
        {
            speed = 2;
        }
        else
        {
            speed = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flipTime > 0)
        {
            flipTime -= Time.deltaTime;
        }
        rb.velocity = new Vector2(speed, 0);

        //Debug.Log("This is  " + flipTime);
        //Debug.Log("This is  " + speed);
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Flipping")
        {
            if (flipTime <= 0)
            {
                if (sr.flipX == false)
                {
                    sr.flipX = true;
                    speed = -speed;
                }
                else
                {
                    sr.flipX = false;
                    speed = -speed;
                }
            }
        }
    }
}

