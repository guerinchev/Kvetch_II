using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossAi : MonoBehaviour
{
    private int phase = 1;
    public Rigidbody2D rb;
    private float speed = 22;
    public SpriteRenderer sr;
    public bool attacking = false;
    public int standAttacks = 1;
    private int counter = 0;
    private BoxCollider2D beamCollider;
    private int orient = 1;


    //added anim here
    public Animator anim;

    protected enum State
    {
        Dash1,
        Dash2,
        Attack,
        Jump,
        Walk,
        Charge,
        Idle
    }

    private State currentState = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        beamCollider = GameObject.Find("boss_test").GetComponent<BoxCollider2D>();
        beamCollider.enabled = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {
            switch (currentState)
            {
                case State.Dash1:
                    StartCoroutine("Dash");
                    break;

                case State.Jump:
                    StartCoroutine("Jump");
                    break;

                case State.Dash2:
                    StartCoroutine("Dash2");
                    break;

                case State.Idle:
                    //StartCoroutine("Idle");
                    idle();
                    break;

                case State.Charge:
                    StartCoroutine("Charge");
                    break;

                case State.Attack:
                    StartCoroutine("Attack");
                    break;

                case State.Walk:
                    //StartCoroutine("walk");
                    walk();
                    break;
            }
        }
    }

    private IEnumerator Dash()
    {
        attacking = true;
        this.anim.SetBool("Dashing", true);
        Debug.Log("dashed");
        if (orient == 1)
        {
            //sr.flipX = false;
            //sr.color = Color.red;
            this.rb.velocity = new Vector2(-speed, 0);
            //sr.flipX = false;
        }
        else
        {
            //sr.flipX = true;
            this.rb.velocity = new Vector2(speed, 0);
            //sr.flipX = true;
        }
        //this.currentState = State.Attack2;
        yield return new WaitForSeconds(2f);
        this.anim.SetBool("Dashing", false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //this.anim.SetBool("Dashing", false);
        this.currentState = State.Walk;
        //this.anim.SetBool("Dashing", false);
        attacking = false;
    }

    private IEnumerator Jump()
    {
        attacking = true;
        Debug.Log("jumped");
        //sr.color = Color.green;
        this.anim.SetBool("Jumping", true);
        this.rb.velocity = new Vector2(0, (speed/2));
        //this.currentState = State.Attack2;
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.currentState = State.Dash1;
        this.anim.SetBool("Jumping", false);
        attacking = false;
    }

    //private IEnumerator Dash2()
    //{
    //    attacking = true;
    //    this.anim.SetBool("Dashing", true);
    //    Debug.Log("dashed2");
    //    sr.color = Color.white;
    //    sr.flipX = true;
    //    this.rb.velocity = new Vector2(-speed, 0);
    //    yield return new WaitForSeconds(2f);
    //    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //    this.anim.SetBool("Dashing", false);
    //    this.currentState = State.Dash1;
    //    //this.anim.SetBool("Dashing", false);
    //    attacking = false;
    //}

    //private IEnumerator Idle()
    //{
    //    attacking = true;
    //    //sr.color = Color.cyan;
    //    //this.anim.SetBool("Bossidle", true);
    //    Debug.Log("Idle");
    //    yield return new WaitForSeconds(2f);
    //    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //    this.currentState = State.Charge;
    //    //sr.color = Color.white;
    //    //this.anim.SetBool("Bossidle", false);
    //    attacking = false;
    //}

    private IEnumerator Charge()
    {
        attacking = true;
        //sr.color = Color.yellow;
        //testspriteanim
        this.anim.SetBool("Charging", true);
        Debug.Log("Charging");
        yield return new WaitForSeconds(1f);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
        this.currentState = State.Attack;
        //sr.color = Color.white;
        this.anim.SetBool("Charging", false);
        attacking = false;
    }

    private IEnumerator Attack()
    {
        attacking = true;
        //sr.color = Color.blue;
        this.anim.SetBool("attacking", true);
        beamCollider.enabled = true;
        Debug.Log("Stand Attack");
        yield return new WaitForSeconds(0.7f);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
        if (standAttacks == 2)
        {
            standAttacks = 1;
            this.currentState = State.Jump;
        }
        else
        {
            standAttacks++;
        }
        //sr.color = Color.white;
        beamCollider.enabled = false;
        this.anim.SetBool("attacking", false);
        attacking = false;
    }

    private void idle()
    {
        attacking = true;
    }

    private void walk()
    {
        //attacking = true;
        if (counter == 0) {
            //sr.flipX = !sr.flipX;
            orient = -orient;
            Debug.Log(orient);
            beamCollider.transform.localScale = new Vector3(orient, 1, 1);
            //orient = -orient;
        }
        this.anim.SetBool("Walking", true);
        float movement = 12 * Time.deltaTime;
        if (counter < 40)
        {
            //this.anim.SetBool("Walking", true);
            //float movement = 12 * Time.deltaTime;
            //transform.position += new Vector3(movement, 0, 0);
            //Debug.Log("walking");
            if (orient == 1)
            {
                rb.transform.Translate(new Vector3(-movement, 0, 0));
            }
            else
            {
                rb.transform.Translate(new Vector3(movement, 0, 0));
            }
            counter++;

            //yield return new WaitForSeconds(3f);
            //this.anim.SetBool("Walking", false);
            //this.currentState = State.Charge;
            //attacking = false;
        }
        else
        {
            this.anim.SetBool("Walking", false);
            this.currentState = State.Charge;
            counter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && phase == 1)
        {
            Debug.Log("done what was meant to happen");
            beamCollider.enabled = false;
            this.currentState = State.Charge;
            attacking = false;
            phase = 2;
        }
    }


}




