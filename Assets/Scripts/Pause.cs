using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public Canvas canvas;
    public GameObject Uihelper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (OVRInput.GetDown(OVRInput.Button.One))
       {
           if (isPaused)
           {
               //Debug.Log("No longer paused");
               isPaused = false;
               canvas.enabled = false;
               Uihelper.SetActive(false);
           }
           else
           {
                //Debug.Log("Iam paused");
                isPaused = true;
                canvas.enabled = true;
                Uihelper.SetActive(true);
           }
       }
      
    }

    public void ExitGame()
    {
        Application.Quit();
        //Debug.Log("Exited");
    }

    public void Resume()
    {
        //Debug.Log("Game resumed");
        isPaused = false;
        canvas.enabled = false;
        Uihelper.SetActive(false);
    }
    
    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Restart()
    {
        //Debug.Log("Restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
