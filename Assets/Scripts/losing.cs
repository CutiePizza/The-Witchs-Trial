using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class losing : MonoBehaviour
{
    public Timer time;
    public Animator fade;
    
    
    void Update()
    {
        if (time.lost == true)
        {
            //Debug.Log("Set trigger");
            fade.SetTrigger("lost");
        }
    }

    public void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
