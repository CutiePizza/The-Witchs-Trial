using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    //reference to collect script
    public collect Collect;
    //reference to Goo script
    public Goo Go;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Collect.isExplode())
        {
            audioSource.clip = audioClips[0];
            audioSource.Play(0);
            Collect.setIsExplode(false);
        }

        if (Collect.isCollect())
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            audioSource.loop = false;
            Collect.setIsCollect(false);
        }
    }
}
