using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupjump : MonoBehaviour
{
    move chara;
    // Start is called before the first frame update
    void Start()
    {

        chara = GameObject.Find("chara").GetComponent<move>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && chara.dashup == false)
        {
            chara.dashup = true;
            chara.dashdown = true;
            chara.dashside = true;
            Debug.Log("dash enabled");
            chara.respawnpoint = GameObject.Find("chara").transform.position;
        }
    }


}
