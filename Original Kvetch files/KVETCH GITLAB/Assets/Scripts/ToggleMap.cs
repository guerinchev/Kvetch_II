using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMap : MonoBehaviour
{
    public Camera mainCam;

    public RawImage map;

    // Start is called before the first frame update
    void Start()
    {
        mainCam.enabled = true;
        map.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                map.enabled = true;
            }
            else
            {
                map.enabled = false;
                Time.timeScale = 1f;
            }
        }
    }
}
