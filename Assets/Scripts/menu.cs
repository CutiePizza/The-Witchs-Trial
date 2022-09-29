using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Animator musicAnim;
    public float waitTime = 2;
   
    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadSceneAsync("level_1");
    }
    
    public void levelSelect()
    {
        StartCoroutine(ChangeScene());   
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        Application.Quit();
        //Debug.Log("Exited");
    }
}
