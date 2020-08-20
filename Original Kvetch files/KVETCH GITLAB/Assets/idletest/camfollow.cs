using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour



{
    public bool playerAlive;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("chara");
        playerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerAlive == true)
        {
            this.gameObject.transform.position = player.transform.position;
        }
    }
}
