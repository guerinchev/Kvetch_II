using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{

    //Checks which powerups have been obtained
    public Vector3 respawnpoint;
    public bool dashside = false;
    public bool dashdown = false;
    public bool dashup = false;
    public bool standAttack = false;

    Transform tr;
    public float speed;
    public Rigidbody2D rb;
    private int maxHealth = 20;
    public int playerHealth = 20;
    public int obtainedKeys = 0;
    public bool canUpDash;
    private bool grounded;
    public Text healthText;
    public Text keyText;
    //private string dashDirection;
    public SpriteRenderer sr;
    public BoxCollider2D hurtbox;

    public Animator anim;

    // For determining which way the player is currently facing.
    public bool m_FacingRight {
        get { return transform.localScale.x > 0; }

    }

    public bool dashing = false; 
    public Vector3 jumpHeight;
    public camfollow camFollow;
    public GameObject cam;


    void Start()
    {
        // Access Object Transform
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        camFollow = GameObject.Find("camParent").GetComponent<camfollow>();
        cam = GameObject.Find("camParent");
        this.anim = GetComponent<Animator>();
        respawnpoint = tr.position;
        this.sr = GetComponent<SpriteRenderer>();
        hurtbox = GameObject.Find("chara").GetComponent<BoxCollider2D>();
        hurtbox.enabled = false;//only active while attacking
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Cast a ray straight down.
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, -transform.up, 1.6f);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + transform.right, -transform.up, 1.6f);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position - transform.right, -transform.up, 1.6f);

        // If it hits something...
        if (hit1.collider != null || hit2.collider != null || hit3.collider != null )
        { 
            canUpDash = true;//reset the ability to updash every time you land on the ground
            if (!grounded)
            {
                grounded = true;
                this.anim.SetBool("IsJumping", false);
            }
            //jump only if standing on the ground
            if (Input.GetKey(KeyCode.W) && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                this.anim.SetTrigger("jump");
                this.anim.SetBool("IsJumping", true);
                grounded = false;
                GetComponent<Rigidbody2D>().AddForce(jumpHeight, (UnityEngine.ForceMode2D)ForceMode.Impulse);
                Debug.Log("GroundDetected");
            }
        }

        //Short rays on either side of the player, for detecting the walls
        Debug.DrawRay(transform.position, transform.right * 1.5f, Color.green);
        Debug.DrawRay(transform.position, -transform.right * 1.5f, Color.green);
        RaycastHit2D RightRay = Physics2D.Raycast(transform.position, transform.right * 1.5f, 1.5f);
        RaycastHit2D LeftRay = Physics2D.Raycast(transform.position, -transform.right * 1.5f, 1.5f);


        if (dashing)//prevents walking mid dash
        {
            return;
        }
        //Makes the player walk. They are stopped slightly before a wall so they don't get stuck on it
        else if (Input.GetKey(KeyCode.A)&& canMove(LeftRay.collider)) 
        {
            float movement = -12 * Time.deltaTime;
            rb.transform.Translate(new Vector3(movement, 0, 0));
        }

        else if (Input.GetKey(KeyCode.D) && canMove(RightRay.collider))
        {
            float movement = 12 * Time.deltaTime;
            rb.transform.Translate(new Vector3(movement, 0, 0));
        }

        else
        {
            this.anim.SetBool("player_walk", false);
        }


        //flip the character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
            this.anim.SetBool("player_walk", true);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
            this.anim.SetBool("player_walk", true);
        }
        transform.localScale = characterScale;

    }



    //Allows the dash to stop after a short wait, so it looks better
    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        dashing = false;
        this.anim.SetBool("IsDashing", false);
    }


    //kills the player, respawns them at last upgrade and resets their health to max
    public void DestructionFunction()
    {
        tr.position = respawnpoint;
        playerHealth = maxHealth;
        healthText.text = "Life: " + playerHealth;
    }

    //take damage, or die, when hit
    public void PlayerDamage()
    {
        if (playerHealth >= 2)
        {
            StartCoroutine("TakeDamage");
        }
        else
        {
            DestructionFunction();
        }
    }

    private IEnumerator TakeDamage()
    {

        playerHealth -= 1;
        sr.color = Color.red; //flash red to indicate damage
        Debug.Log("Health equals " + playerHealth);
        healthText.text = "Life: " + playerHealth;//update text on screen
        if (m_FacingRight)
        {
            rb.AddForce(Vector3.left * 3000);//knockback when damage is taken
        }
        else
        {
            rb.AddForce(Vector3.right * 3000);
        }
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }


    //Handles non-dangerous collisions, such as picking up items and opeing doors
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "key")
        {
            obtainedKeys += 1;
            Destroy(collision.gameObject);
            keyText.text = "Keys: " + obtainedKeys;//update text on screen
            Debug.Log("Key" + obtainedKeys + "obtained");
        }
        else if(collision.gameObject.tag == "door" && obtainedKeys == 6)
        {
            obtainedKeys = 0;//resets keys so second door can be opened later
            Destroy(collision.gameObject);//opens door
            keyText.text = "Keys: " + obtainedKeys;
            Debug.Log("Keys Reset");
        }
        else if (collision.gameObject.tag == "health")
        {
            Destroy(collision.gameObject);
            if(playerHealth < maxHealth)
            {
                playerHealth += 1;//restores health
                Debug.Log("Health equals " + playerHealth);
                healthText.text = "Life: " + playerHealth;
            }
        }
    }

    //prevents the raycasting from stopping the player at triggers, keys and health packs
    private bool canMove(Collider2D col)
    {
        if(col == null)
        {
            return true;
        }
        else if(col.tag.Equals("key") || col.tag.Equals("health") || col.tag.Equals("Flipping")
        || col.tag.Equals("Trigger"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
