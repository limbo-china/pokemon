using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance;
    AudioSource audioSource;
    AudioClip clickClip, selectClip;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clickClip = Resources.Load<AudioClip>("Audio/click");
        selectClip = Resources.Load<AudioClip>("Audio/select");
    }
    public void playSelectClip()
    {
        if (selectClip != null)
        {
            audioSource.PlayOneShot(selectClip);
        }
    }
    public void playClickClip()
    {
        if (clickClip != null)
        {
            audioSource.PlayOneShot(clickClip);
        }
    }

}
