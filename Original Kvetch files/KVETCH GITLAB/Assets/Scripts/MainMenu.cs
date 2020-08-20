using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static bool isOpen = false;
    public GameObject startMenuUI;
    public GameObject backGroundUI;
    private float timeLeft = 37.0f;


    private void Start()
    {
        startMenuUI.SetActive(false);
        backGroundUI.SetActive(false);
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            isOpen = true;
            startMenuUI.SetActive(true);
            backGroundUI.SetActive(true);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("ByrneTabitha_KVETCH_P2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
