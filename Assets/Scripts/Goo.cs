using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class Goo to start the time
// add time when colliding with pink ring
// remove time when colliding with red ring
// check if win or not and add animations

public class Goo : MonoBehaviour
{
    //reference to script Timer
    public Timer timer;
    //Animator of the timer text
    public Animator m_Animator;
    //Animator of the Plus text
    public Animator Plus;
    //ANimator of the Minus text
    public Animator Minus;
    //reference to the collect script
    public collect diamond;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Go")
        {
            //Debug.Log("Timer on enter");
            m_Animator.SetTrigger("isOn");
            timer.timerIsRunning = true;
        }
        if (other.tag == "PinkRing")
        {
            Plus.SetTrigger("Plus 0");
            timer.timeRemaining += 3;
        }

        if (other.tag == "RedRing")
        {
            Minus.SetTrigger("minus");
            timer.timeRemaining -= 5;
        }

        if (other.tag == "Win" && diamond.checkDiamond() == true)
        {
            timer.timerIsRunning = false;
           // Debug.Log("You won");
            timer.timeText.color = Color.green;
        }
        else if (other.tag == "Win" && diamond.checkDiamond() == false)
        {
            timer.timerIsRunning = false;
            //Debug.Log("You lost, you have not enough diamonds");
            timer.timeText.color = Color.red;
            timer.lost = true;
        }

    }

}
