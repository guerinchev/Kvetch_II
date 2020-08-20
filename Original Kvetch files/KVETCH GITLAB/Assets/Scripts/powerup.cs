using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    private move chara;
    public string PowerUp;
    public SpriteRenderer powersign;


    // Start is called before the first frame update
    void Start()
    {
        powersign.enabled = false;
        chara = GameObject.Find("chara").GetComponent<move>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision COmfirmed");
        if (collision.gameObject.tag == "Player")
        {
            if (this.PowerUp.Equals("Side") && chara.dashside == false)
            {
                chara.dashside = true;
                //StartCoroutine("FlashWait");
                powersign.enabled = true;
                Debug.Log("side dash enabled");
            }
            if (this.PowerUp.Equals("Down") && chara.dashdown == false)
            {
                //chara.dashside = true;
                chara.dashdown = true;
                powersign.enabled = true;
                Debug.Log("down dash enabled");
            }
            if (this.PowerUp.Equals("Up") && chara.dashup == false)
            {
                //chara.dashside = true;
                //chara.dashdown = true;
                chara.dashup = true;
                powersign.enabled = true;
                Debug.Log("up dash enabled");
            }
            if (this.PowerUp.Equals("SAttack") && chara.standAttack == false)
            {
                //chara.dashside = true;
                //chara.dashdown = true;
                chara.standAttack = true;
                powersign.enabled = true;
                Debug.Log("stand atttack enabled");
            }
            Debug.Log("End Reached");
            chara.respawnpoint = GameObject.Find("chara").transform.position;
        }
    }


    private IEnumerator FlashWait()
    {
        chara.sr.color = Color.cyan;
        yield return new WaitForSeconds(1f);
        chara.sr.color = Color.white;
    }


}
