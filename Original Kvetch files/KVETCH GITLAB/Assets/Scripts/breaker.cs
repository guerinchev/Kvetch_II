using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaker : MonoBehaviour
{
    // Start is called before the first frame update
    // Set renderer
    Renderer rend;
    // Set transform
    Transform tran;
    public move player;
    void Start()
    {
        //Get renderer
        rend = GetComponent<Renderer>();
        //Get transform
        tran = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "chara")
        {
            //player.DestructionFunction();
            Destroy(gameObject);
        }
    }
}