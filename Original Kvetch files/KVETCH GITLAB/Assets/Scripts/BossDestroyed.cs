using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDestroyed : MonoBehaviour
{
    public GameObject boss;

    public GameObject body;

    private float rollCreditsTime = 7.3f;

    private void Start()
    {
        body.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.Equals(null))
        {
            rollCreditsTime -= Time.deltaTime;
            body.SetActive(true);
            if (rollCreditsTime <= 0)
            {
                SceneManager.LoadScene("CreditsScene");
            }
        }
    }
}
