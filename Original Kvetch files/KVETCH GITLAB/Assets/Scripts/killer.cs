using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killer : MonoBehaviour
{
    // Start is called before the first frame update
    // Set renderer
    Renderer rend;
    // Set transform
    Transform tran;
    public move player;
    private BoxCollider2D box;
    private int health;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bigenemy enem;

    public GameObject player_prefab;

    void Start()
    {
        //Get renderer
        rend = GetComponent<Renderer>();
        if (!(this.gameObject.name.Contains("boss"))) {
            enem = this.gameObject.GetComponent<bigenemy>();
        }
        //Get transform
        tran = GetComponent<Transform>();
        //Get Trigger
        box = GetComponent<BoxCollider2D>();
        this.sr = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody2D>();
        if (this.gameObject.name.Contains("V"))
        {
            health = 900;
        }
        else if (this.gameObject.name.Equals("tallGreen"))
        {
            health = 6;
        }
        else if (this.gameObject.name.Contains("camera"))
        {
            health = 2;
        }
        else if (this.gameObject.name.Contains("flower"))
        {
            health = 3;
        }
        else if (this.gameObject.name.Contains("boss_t"))
        {
            health = 20;
        }
        else
        {
            health = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (player.dashing)
            {
                if (health == 1)
                {
                    Debug.Log("Destoying this object");
                    Destroy(this.gameObject);
                }
                else
                {
                    StartCoroutine("Damage");
                }
            }
            else
            {
                player.PlayerDamage();
                Debug.Log("Damage");
                //StartCoroutine(Respawn());
                if (sr.flipX && !(this.gameObject.name.Contains("boss")))
                {
                    sr.flipX = false;
                    enem.speed = -enem.speed;
                }
                else if (!(this.gameObject.name.Contains("boss")))
                {
                    sr.flipX = true;
                    enem.speed = -enem.speed;
                }
            }

        }

    }


    public IEnumerator Damage()
    {
        health -= 1;
        sr.color = Color.red; //flash red to indicate damage
        //Debug.Log("Health equals " + health);
        if (player.m_FacingRight && !(this.gameObject.name.Contains("boss")))
        {
            //rb.AddForce(Vector3.left * 3000);//knockback when damage is taken
            //rb.gameObject.
            if (sr.flipX)
            {
                sr.flipX = false;
                enem.speed = -enem.speed;
            }
        }
        else if (!(this.gameObject.name.Contains("boss")))
        {
            //rb.AddForce(Vector3.right * 3000);
            //enem.speed = -enem.speed;
            if (!sr.flipX)
            {
                sr.flipX = true;
                enem.speed = -enem.speed;
            }
        }
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }

    IEnumerator Dead()
    {
        Debug.Log("dead");
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        Debug.Log("respawn");
        GetComponent<Renderer>().enabled = true;
    }


    IEnumerator Respawn()
    {
        Debug.Log("dead");

        yield return new WaitForSeconds(1);
        Debug.Log("respawn");
        SceneManager.LoadScene(0);
    }
}