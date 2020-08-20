using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour

{

    private move chara;
    private string dashDirection;
    //private Collider2D attackRange;

    // Start is called before the first frame update
    void Start()
    {
        chara = GetComponent<move>();
        chara.hurtbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && chara.dashing == false)
        {

            if (Input.GetKey(KeyCode.W) && chara.dashup)
            {
                if (chara.canUpDash)//prevents infinte up dashing
                {
                    chara.dashing = true;
                    dashDirection = "up";
                    chara.anim.SetBool("UpDashing", true);
                    Debug.Log("Dash Up");
                    chara.rb.AddForce(Vector3.up * 7000);
                    chara.canUpDash = false;
                    StartCoroutine("StopDash");

                }
                else
                {
                    Debug.Log("No repeat dash");
                    chara.dashing = false;
                }
            }
            else if (Input.GetKey(KeyCode.S) && chara.dashdown)
            {
                chara.dashing = true;
                dashDirection = "down";
                chara.anim.SetBool("DownDashing", true);
                Debug.Log(dashDirection + "dashed");
                chara.rb.AddForce(Vector3.down * 7000);
                StartCoroutine("StopDash");


            }
            else if (chara.m_FacingRight && chara.dashside)
            {
                chara.dashing = true;
                dashDirection = "leftRight";
                chara.anim.SetTrigger("dash");
                chara.anim.SetBool("IsDashing", true);
                Debug.Log("Dash Right");
                chara.rb.AddForce(Vector3.right * 7000);
                StartCoroutine("StopDash");
            }
            else if (chara.dashside)
            {
                chara.dashing = true;
                dashDirection = "leftRight";
                chara.anim.SetTrigger("dash");
                chara.anim.SetBool("IsDashing", true);
                Debug.Log("Dash Left");
                chara.rb.AddForce(Vector3.left * 7000);
                StartCoroutine("StopDash");
            }
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)) && chara.standAttack)
        {
            chara.hurtbox.enabled = true;
            chara.anim.SetBool("Stand_Attack", true);
            StartCoroutine("attackA");
            dashDirection = "na";
            chara.dashing = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            chara.hurtbox.enabled = false;
            chara.dashing = false;
        }

    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        chara.dashing = false;
        chara.anim.SetBool("IsDashing", false);
        chara.anim.SetBool("UpDashing", false);
        chara.anim.SetBool("DownDashing", false);
        chara.anim.SetBool("Stand_Attack", false);
        chara.hurtbox.enabled = false;
    }

    private IEnumerator attackA()
    {
        yield return new WaitForSeconds(0.2f);
        chara.anim.SetBool("Stand_Attack", false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))) && Breakable(other) && chara.standAttack)
        {
            chara.dashing = true;
           //chara.hurtbox.enabled = true;
            chara.anim.SetBool("Stand_Attack", true);
            Destroy(other.gameObject);
            StartCoroutine("StopDash");
            //Destroy(other.gameObject);
            //StartCoroutine("wait");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (chara.dashing == true)
        {
            if (collision.gameObject.tag == "LRBreak" && dashDirection.Equals("leftRight"))
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "UpBreak" && dashDirection.Equals("up"))
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "DownBreak" && dashDirection.Equals("down"))
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "break")
            {
                //Destroy(collision.gameObject);
            }

        }
        else if (collision.gameObject.tag == "break")
        {
            chara.PlayerDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (chara.dashing)
        {
            if (
            (collision.gameObject.tag == "LRBreak" && dashDirection.Equals("leftRight")) ||
            (collision.gameObject.tag == "UpBreak" && dashDirection.Equals("up")) ||
            (collision.gameObject.tag == "DownBreak" && dashDirection.Equals("down")))
            {
                Destroy(collision.gameObject);
            }
        }
        else if (((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))) && Breakable(collision) && chara.standAttack)
        {
            chara.dashing = true;
            //chara.hurtbox.enabled = true;
            chara.anim.SetBool("Stand_Attack", true);
            //Destroy(collision.gameObject);
            StartCoroutine("StopDash");
            //Destroy(other.gameObject);
            //StartCoroutine("wait");
        }
        else if (collision.gameObject.tag == "break")
            {
            chara.PlayerDamage();
        }
    }

    private bool Breakable(Collider2D coll)
    {
        if(coll.gameObject.tag == "break")
        {
            return true;
        }
        else { return false; }
    }
}
