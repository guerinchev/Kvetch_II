using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip audioClip;

    public GameObject musicTrigger;

    public AudioClip nextClip;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    private void Update()
    {
        if (musicTrigger.GetComponent<TriggerMusic>().IsTriggered())
        {
            
            
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
                audioSource.clip = nextClip;
                audioSource.Play();
            }
            
        }
    }
}
