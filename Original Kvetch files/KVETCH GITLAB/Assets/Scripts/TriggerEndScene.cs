using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TriggerEndScene : MonoBehaviour
{
    private bool triggered;

    public VideoClip bossScene;
    public VideoPlayer videoPlayer;

    public AudioSource oldMusic;

    public AudioClip finalMusic;
    public AudioSource musicPlayer;

    internal bool IsTriggered()
    {
        return triggered;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!triggered)
            {
                videoPlayer.Prepare();
                oldMusic.Pause();
                triggered = true;
                Time.timeScale = 0f;
                videoPlayer.clip = bossScene;
                videoPlayer.Play();
                videoPlayer.loopPointReached += EndVideo;
            }
        }
    }

    private void EndVideo(VideoPlayer source)
    {

        Time.timeScale = 1f;
        musicPlayer.clip = finalMusic;
        musicPlayer.Play();
        source.enabled = false;
    }
}
