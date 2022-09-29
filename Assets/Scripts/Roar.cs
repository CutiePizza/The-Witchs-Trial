using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : MonoBehaviour
{

    private Animator dragon;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        dragon = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Scream()
    {
        //Debug.Log("I am screaming");
        audioSource.Play();
    }

}
