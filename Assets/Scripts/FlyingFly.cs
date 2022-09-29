using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFly : MonoBehaviour
{
   
    public GameObject head;
    public GameObject rightHand;
    public broom Witchbroom;
    public float speed = 8f;
    public Pause pause;
    
    private bool isFlying = false;
    private float GrabRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
    private float GrabLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
    private bool Rpressed = false;
    //private bool Lpressed = false;
 
    private void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.isPaused == false)
        {
            // Get values of controllers for grab
            GrabRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
            GrabLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);

            CheckFlying();
            Fly();
        }
    }

    // Check if the broom is grabbed
    private bool GotBroom()
    {
        //Checking if we are grabbbing with left or right
        if (GrabRight > 0.9 || GrabLeft > 0.9)
        {
            //Debug.Log("Right or left Grab pressed");
            Rpressed = true;
        }
        else
            Rpressed = false;

       /* if (GrabLeft > 0.9)
        {
            Debug.Log("Left Grab pressed");
            Lpressed = true;
        }
        else
            Lpressed = false;*/
        //Checking if we collieded with the broom and grabbing it
        if (Witchbroom.BroomIsGrabbed == true && Rpressed == true)
            return (true);
        else
            return (false);
    }
    // CHeck if flying
    private void CheckFlying()
    {
        
        if (GotBroom() == true && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isFlying = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isFlying = false;
        }
    }
    // Fly method
    private void Fly()
    {
        if (isFlying)
        {
            GetComponent<OVRPlayerController>().enabled = false;
            Vector3 flyDirection = (rightHand.transform.position - head.transform.position);
            transform.position += flyDirection.normalized * speed * Time.deltaTime;
        }
        else
        {
            GetComponent<OVRPlayerController>().enabled = true;
        }
    }
}
